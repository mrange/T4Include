// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// If you cannot locate the  Microsoft Public License, please send an email to 
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------

// ### INCLUDE: ../Common/Log.cs
// ### INCLUDE: ShutDownable.cs
// ### INCLUDE: RemainingTime.cs

// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier

namespace Source.Concurrency
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Source.Common;

    sealed partial class SequentialTaskScheduler : TaskScheduler, IShutDownable
    {
        const int                           DefaultTimeOutInMs = 250;
        public readonly string              Name    ;
        public readonly TimeSpan            TimeOut ;

        readonly BlockingCollection<Task>   m_tasks = new BlockingCollection<Task>();
        Thread                              m_executingThread   ;
        bool                                m_done              ;

        int                                 m_taskFailureCount;


        partial void Partial_ThreadCreated (Thread thread);

        partial void Partial_TaskFailed (Task task, Exception exc, int failureCount, ref bool done);

        public SequentialTaskScheduler (string name, TimeSpan? timeOut = null, ApartmentState apartmentState = ApartmentState.Unknown)
        {
            Name                = name      ?? "UnnamedTaskScheduler";
            TimeOut             = timeOut   ?? TimeSpan.FromMilliseconds (DefaultTimeOutInMs);
            m_executingThread   = new Thread (OnRun)
                           {
                               IsBackground = true
                           };

            m_executingThread.SetApartmentState (apartmentState);

            Partial_ThreadCreated (m_executingThread);

            m_executingThread.Start ();
        }

        void OnRun (object context)
        {
            while (!m_done)
            {
                Task task;
                try
                {
                    if (m_tasks.TryTake (out task, TimeOut))
                    {
                        // null task means exit
                        if (task == null)
                        {
                            m_done = true;
                            continue;
                        }

                        if (!TryExecuteTask (task))
                        {
                            Log.Warning (
                                "SequentialTaskScheduler.OnRun: {0} - TryExecuteTask failed for task: {1}",
                                Name,
                                task.Id
                                );
                        }
                    }
                }
                catch (Exception exc)
                {
                    ++m_taskFailureCount;

                    Log.Exception (
                        "SequentialTaskScheduler.OnRun: {0} - Caught exception: {1}",
                        Name,
                        exc
                        );

                    Partial_TaskFailed (task, exc, m_taskFailureCount, ref m_done);
                }
            }
        }

        protected override bool TryDequeue (Task task)
        {
            Log.Warning ("SequentialTaskScheduler.TryDequeue: {0} - Task dequeing not supported", Name);
            return false;
        }

        protected override void QueueTask (Task task)
        {
            m_tasks.Add (task);
        }

        protected override bool TryExecuteTaskInline (Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }

        protected override IEnumerable<Task> GetScheduledTasks ()
        {
            return m_tasks.ToArray ();
        }

        public int TasksInQueue
        {
            get { return m_tasks.Count; }
        }

        public bool IsDisposed
        {
            get { return m_executingThread == null; }
        }

        public void SignalShutDown ()
        {
            if (!m_done)
            {
                m_done = true;
                // null task to wake up thread
                m_tasks.Add (null);                
            }
        }

        public void ShutDown (RemainingTime remainingTime)
        {
            var thread = Interlocked.Exchange (ref m_executingThread, null);
            if (thread != null)
            {
                try
                {
                    SignalShutDown ();
                    var joinTimeOut = (int)remainingTime.Remaining.TotalMilliseconds/2;
                    if (!thread.Join (joinTimeOut))
                    {
                        Log.Warning (
                            "SequentialTaskScheduler.Dispose: {0} - Executing thread didn't shutdown, aborting it...",
                            Name
                            );        

                        thread.Abort ();
                        var abortTimeOut = remainingTime.Remaining;
                        if (!thread.Join (abortTimeOut))
                        {
                            Log.Warning (
                                "SequentialTaskScheduler.Dispose: {0} - Executing thread didn't shutdown after abort, ignoring it...",
                                Name
                                );
                        }
                    }
                }
                catch (Exception exc)
                {
                    Log.Exception (
                        "SequentialTaskScheduler.Dispose: {0} - Caught exception: {1}",
                        Name,
                        exc
                        );
                }
            }
            
        }

        public void Dispose ()
        {
            ShutDown (new RemainingTime (TimeOut));
        }
    }
}
