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


// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local
// ReSharper disable PartialTypeWithSinglePart

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FileInclude.Source.Concurrency;
using FileInclude.Source.Extensions;
using FileInclude.Source.Testing;

#pragma warning disable 0649

namespace Test_Functionality.Concurrency
{
    sealed partial class TestsFor_TaskSchedulers
    {
        public void Disabled_Test_TaskScheduler_Basic ()
        {
            var sequentialTaskScheduler = new SequentialTaskScheduler (
                "TestScheduler"
                );
    
            var taskFactory = new TaskFactory (sequentialTaskScheduler);

            var usageCount = 0;

            var stopwatch = new Stopwatch ();
            
            stopwatch.Start ();

            var firstTask = taskFactory.StartNew (() => {Thread.Sleep (500); ++usageCount;});
            var secondTask = taskFactory.StartNew (() => {Thread.Sleep (500); ++usageCount;});

            firstTask.Wait ();
            secondTask.Wait ();

            stopwatch.Stop ();

            TestFor.Equality(2, usageCount, "Both tasks are expected to be executed");
            TestFor.Equality(true, Math.Abs(stopwatch.ElapsedMilliseconds - 1000) < 100, "Elapsed time is expected to be around 1 sec");

            sequentialTaskScheduler.DisposeNoThrow();
        }

        public void Test_TaskScheduler_ShutDown ()
        {
            var sequentialTaskScheduler = new SequentialTaskScheduler (
                "TestScheduler"
                );
    
            var taskFactory = new TaskFactory (sequentialTaskScheduler);

            var usageCount = 0;

            var firstTask = taskFactory.StartNew (() => {Thread.Sleep (500); ++usageCount;});
            var secondTask = taskFactory.StartNew (() => {Thread.Sleep (500); ++usageCount;});

            var stopwatch = new Stopwatch ();
            stopwatch.Start ();

            var remainingTime = new RemainingTime (TimeSpan.FromMilliseconds(4000));
            sequentialTaskScheduler.ShutDown(remainingTime);

            stopwatch.Stop();
            TestFor.Equality(true, stopwatch.ElapsedMilliseconds < 750, "Shutdwn time is expected to be less than 0.75 sec");
        }
    }

}