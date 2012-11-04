


// @@@ SKIPPING (Blacklisted): C:\temp\GitHub\T4Include\NonSource\Source\Program.cs

// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # text template file (.tt)                                                      #
// ############################################################################



// ############################################################################
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\BaseDisposable.cs
// @@@ INCLUDE_FOUND: Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\ConsoleLog.cs
// @@@ INCLUDE_FOUND: Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\HRON.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ INCLUDE_FOUND: Generated_Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Concurrency\Atomic.cs
// @@@ INCLUDE_FOUND: IAtomic.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Concurrency\IAtomic.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Concurrency\TaskSchedulers.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\NumericalExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\EnumerableExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Generated_Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Concurrency\IAtomic.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// ############################################################################
// Certains directives such as #define and // Resharper comments has to be 
// moved to top in order to work properly    
// ############################################################################
// ReSharper disable CompareOfFloatsByEqualityOperator
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel
// ReSharper disable RedundantNameQualifier
// ############################################################################

// ############################################################################
namespace ProjectInclude
{
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
    
    namespace Source.Common
    {
        static class Array<T>
        {
            public static readonly T[] Empty = new T[0];
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    namespace Source.Common
    {
        using System;
        using System.Threading;
    
        abstract partial class BaseDisposable : IDisposable
        {
            int m_isDisposed;
    
            public bool IsDisposed
            {
                get { return m_isDisposed != 0; }
            }
    
            public void Dispose ()
            {
                if (Interlocked.Exchange (ref m_isDisposed, 1) == 0)
                {
                    try
                    {
                        OnDispose ();
                    }
                    catch (Exception exc)
                    {
                        Log.Exception (
                            "BaseDisposable.Dispose for {0}, caught exception: {1}", 
                            GetType ().FullName,
                            exc
                            );
                    }
                }            
            }
    
            protected abstract void OnDispose ();
        }
    
    }
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    
    namespace Source.Common
    {
        using System;
        using System.Globalization;
    
        partial class Log
        {
            static readonly object s_colorLock = new object ();
            static partial void Partial_LogMessage (Level level, string message)
            {
                var now = DateTime.Now;
                var finalMessage = string.Format (
                    CultureInfo.InvariantCulture,
                    "{0:HHmmss} {1}:{2}",
                    now,
                    GetLevelMessage (level),
                    message
                    );
                lock (s_colorLock)
                {
                    var oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = GetLevelColor (level);
                    try
                    {
                        Console.WriteLine (finalMessage);
                    }
                    finally
                    {
                        Console.ForegroundColor = oldColor;
                    }
    
                }
            }
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
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
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
    
    
    namespace Source.Common
    {
        using System;
    
        partial class Log
        {
            public enum Level
            {
                Success = 1000,
                HighLight = 2000,
                Info = 3000,
                Warning = 10000,
                Error = 20000,
                Exception = 21000,
            }
    
            public static void Success (string format, params object[] args)
            {
                LogMessage (Level.Success, format, args);
            }
            public static void HighLight (string format, params object[] args)
            {
                LogMessage (Level.HighLight, format, args);
            }
            public static void Info (string format, params object[] args)
            {
                LogMessage (Level.Info, format, args);
            }
            public static void Warning (string format, params object[] args)
            {
                LogMessage (Level.Warning, format, args);
            }
            public static void Error (string format, params object[] args)
            {
                LogMessage (Level.Error, format, args);
            }
            public static void Exception (string format, params object[] args)
            {
                LogMessage (Level.Exception, format, args);
            }
            static ConsoleColor GetLevelColor (Level level)
            {
                switch (level)
                {
                    case Level.Success:
                        return ConsoleColor.Green;
                    case Level.HighLight:
                        return ConsoleColor.White;
                    case Level.Info:
                        return ConsoleColor.Gray;
                    case Level.Warning:
                        return ConsoleColor.Yellow;
                    case Level.Error:
                        return ConsoleColor.Red;
                    case Level.Exception:
                        return ConsoleColor.Red;
                    default:
                        return ConsoleColor.Magenta;
                }
            }
    
            static string GetLevelMessage (Level level)
            {
                switch (level)
                {
                    case Level.Success:
                        return "SUCCESS  ";
                    case Level.HighLight:
                        return "HIGHLIGHT";
                    case Level.Info:
                        return "INFO     ";
                    case Level.Warning:
                        return "WARNING  ";
                    case Level.Error:
                        return "ERROR    ";
                    case Level.Exception:
                        return "EXCEPTION";
                    default:
                        return "UNKNOWN  ";
                }
            }
    
        }
    }
    
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    using System.Collections;
    
    namespace Source.Common
    {
        using System.Collections.Generic;
        using System.Text;
    
        partial class HRONParseError
        {
            public readonly int LineNo;
            public readonly string Line;
            public readonly HRON.ParseError ParseError;
    
            public HRONParseError(int lineNo, string line, HRON.ParseError parseError)
            {
                LineNo = lineNo;
                Line = line;
                ParseError = parseError;
            }
        }
    
        partial interface IHRONEntity
        {
            HRON.Type Type { get; }
    
            void ToString (StringBuilder sb);
        }
    
        abstract partial class BaseHRONEntity : IHRONEntity
        {
            public abstract HRON.Type Type { get; }
            public abstract void ToString(StringBuilder sb);
    
            public override string ToString()
            {
                var sb = new StringBuilder(128);
                ToString(sb);
                return sb.ToString();
            }
        }
    
        sealed partial class HRONObject : BaseHRONEntity
        {
            public struct Pair
            {
                readonly string m_name;
                readonly IHRONEntity m_value;
    
                public Pair(string name, IHRONEntity value)
                    : this()
                {
                    m_name = name;
                    m_value = value;
                }
    
                public string Name
                {
                    get { return m_name ?? ""; }
                }
    
                public IHRONEntity Value
                {
                    get { return m_value ?? HRONEmpty.DefaultValue; }
                }
    
                public override string ToString()
                {
                    return Name + " : " + Value;
                }
            }
    
            public readonly Pair[] Pairs;
    
            public HRONObject(Pair[] pairs)
            {
                Pairs = pairs ?? Array<Pair>.Empty;
            }
    
            public override HRON.Type Type
            {
                get { return HRON.Type.Object; }
            }
    
            public override void ToString(StringBuilder sb)
            {
                sb.Append("{Object");
                foreach (var pair in Pairs)
                {
                    sb.Append(", ");
                    sb.Append(pair.Name);
                    sb.Append(" : ");
                    pair.Value.ToString(sb);
                }
                sb.Append("}");
            }
        }
    
        sealed partial class HRONValue : BaseHRONEntity
        {
            public readonly string Value;
    
            public HRONValue(string value)
            {
                Value = value ?? "";
            }
    
            public override HRON.Type Type
            {
                get { return HRON.Type.Value; }
            }
    
            public override void ToString(StringBuilder sb)
            {
                sb.Append("Value = '");
                sb.Append(Value);
                sb.Append("'");
            }
        }
    
        sealed partial class HRONComment : BaseHRONEntity
        {
            public readonly string Comment;
    
            public HRONComment(string comment)
            {
                Comment = comment ?? "";
            }
    
            public override HRON.Type Type
            {
                get { return HRON.Type.Comment; }
            }
    
            public override void ToString(StringBuilder sb)
            {
                sb.Append("Comment = '");
                sb.Append(Comment);
                sb.Append("'");
            }
        }
    
        sealed partial class HRONEmpty : BaseHRONEntity
        {
            public static readonly HRONEmpty DefaultValue = new HRONEmpty();
    
            public override HRON.Type Type
            {
                get { return HRON.Type.Empty; }
            }
    
            public override void ToString(StringBuilder sb)
            {
                sb.Append("Empty");
            }
        }
    
        partial interface IHRONParseVisitor
        {
            void Empty(string name);
            void Comment(string comment);
            void Value(string name, string value);
            void BeginObject(string name);
            void EndObject(string name);
    
            void ParseError(int lineNo, string line, HRON.ParseError parseError);
        }
    
        static partial class HRON
        {
            public enum Type
            {
                Value,
                Object,
                Comment,
                Empty,
            }
    
            enum ParseState
            {
                ExpectingTag,
                ExpectingValue,
                BuildingValue,
            }
    
            public enum ParseError
            {
                IndentIncreasedMoreThanExpected,
                TagIsNotCorrectlyFormatted
            }
    
            sealed partial class BuildObjectVisitor : IHRONParseVisitor
            {
                public struct Item
                {
                    public readonly string Name;
                    public List<HRONObject.Pair> Pairs;
    
                    public Item (string name): this()
                    {
                        Name = name ?? "";
                        Pairs = new List<HRONObject.Pair>();
                    }
                }
    
                public readonly Stack<Item> Stack = new Stack<Item>();
                public readonly List<HRONParseError> Errors = new List<HRONParseError>();
                public readonly int MaxErrors;
    
                public BuildObjectVisitor (int maxErrors)
                {
                    MaxErrors = maxErrors;
                    Stack.Push(new Item("Root"));
                }
    
                public void Empty (string name)
                {
                    AddEntity(name, new HRONEmpty()); 
                }
    
                public void Comment(string comment)
                {
    //                AddEntity("", new HRONComment(comment));
                }
    
                public void Value(string name, string value)
                {
                    AddEntity(name, new HRONValue(value));
                }
    
                public void BeginObject(string name)
                {
                    Stack.Push(new Item(name));
                }
    
                public void EndObject(string name)
                {
                    var pop = Stack.Pop();
                    AddEntity(pop.Name, new HRONObject (pop.Pairs.ToArray()));
                }
    
                void AddEntity(string name, IHRONEntity entity)
                {
                    Stack.Peek().Pairs.Add(new HRONObject.Pair(name, entity));
                }
    
                public void ParseError(int lineNo, string line, ParseError parseError)
                {
                    Errors.Add(new HRONParseError(lineNo, line, parseError));
                }
            }
    
            public static bool TryParse(
                int maxErrorCount,
                IEnumerable<string> lines,
                out HRONObject hronObject,
                out HRONParseError[] errors
                )
            {
                hronObject = null;
                errors = Array<HRONParseError>.Empty;
    
                var visitor = new BuildObjectVisitor(maxErrorCount);
    
                Parse(maxErrorCount, lines, visitor);
    
                if (visitor.Errors.Count > 0)
                {
                    errors = visitor.Errors.ToArray();
                    return false;
                }
    
                hronObject = new HRONObject(visitor.Stack.Peek().Pairs.ToArray());
    
                return true;
            }
    
            public static void Parse(
                int maxErrorCount,
                IEnumerable<string> lines,
                IHRONParseVisitor visitor
                )
            {
                if (visitor == null)
                {
                    return;
                }
    
                lines = lines ?? Array<string>.Empty;
    
                var state = ParseState.ExpectingTag;
                var indention = 0;
                var lineNo = 0;
                var sb = new StringBuilder(80);
                var context = new Stack<string>();
    
                foreach (var line in lines)
                {
                    ++lineNo;
                    if (string.IsNullOrEmpty(line))
                    {
                        visitor.Empty(context.Peek());
                        continue;
                    }
    
                    var lineIndention = 0;
                    var lineLength = line.Length;
    
                    for (var iter = 0; iter < lineLength; ++iter)
                    {
                        var ch = line[iter];
                        if (ch == '\t')
                        {
                            ++lineIndention;
                        }
                        else
                        {
                            iter = lineLength;
                        }
                    }
    
                    if (lineIndention > indention)
                    {
                        visitor.ParseError(lineNo, line, ParseError.IndentIncreasedMoreThanExpected);
                        continue;
                    }
    
                    var isComment = lineIndention < lineLength && line[lineIndention] == '#';
    
                    if (isComment)
                    {
                        visitor.Comment(line.Substring(lineIndention + 1));
                    }
                    else
                    {
                        if (lineIndention < indention)
                        {
                            switch (state)
                            {
                                case ParseState.ExpectingTag:
                                    for (var iter = lineIndention; iter < indention; ++iter)
                                    {
                                        visitor.EndObject(context.Peek());
                                        context.Pop();
                                    }
                                    break;
                                case ParseState.ExpectingValue:
                                case ParseState.BuildingValue:
                                default:
                                    visitor.Value(context.Peek(), sb.ToString());
                                    // Popping the string name
                                    context.Pop();
                                    for (var iter = lineIndention + 1; iter < indention; ++iter)
                                    {
                                        visitor.EndObject(context.Peek());
                                        context.Pop();
                                    }
                                    break;
                            }
    
                            indention = lineIndention;
                            state = ParseState.ExpectingTag;
                        }
    
                        switch (state)
                        {
                            case ParseState.ExpectingTag:
                                var existingIndention = indention;
                                sb.Clear();
                                for (var iter = lineIndention; iter < lineLength; ++iter)
                                {
                                    var ch = line[iter];
                                    switch (ch)
                                    {
                                        case ':':
                                            state = ParseState.ExpectingTag;
                                            ++indention;
                                            iter = lineLength;
                                            context.Push(sb.ToString());
                                            visitor.BeginObject(context.Peek());
                                            break;
                                        case '=':
                                            state = ParseState.ExpectingValue;
                                            ++indention;
                                            iter = lineLength;
                                            context.Push(sb.ToString());
                                            break;
                                        default:
                                            sb.Append(ch);
                                            break;
                                    }
    
                                }
    
                                if (existingIndention == indention)
                                {
                                    visitor.ParseError(lineNo, line, ParseError.TagIsNotCorrectlyFormatted);
                                }
    
                                // TODO: Validate no trailing characters
    
                                break;
                            case ParseState.ExpectingValue:
                                sb.Clear();
                                sb.Append(line, indention, lineLength - indention);
                                state = ParseState.BuildingValue;
                                break;
                            case ParseState.BuildingValue:
                            default:
                                sb.AppendLine();
                                sb.Append(line, indention, lineLength - indention);
                                break;
                        }
                    }
    
                }
            }
    
        }
    
    }
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    
    namespace Source.Common
    {
        using System;
        using System.Globalization;
    
        static partial class Log
        {
            static partial void Partial_LogMessage (Level level, string message);
            static partial void Partial_ExceptionOnLog (Level level, string format, object[] args, Exception exc);
    
            public static void LogMessage (Level level, string format, params object[] args)
            {
                try
                {
                    Partial_LogMessage (level, GetMessage (format, args));
                }
                catch (Exception exc)
                {
                    Partial_ExceptionOnLog (level, format, args, exc);
                }
                
            }
    
            static string GetMessage (string format, object[] args)
            {
                format = format ?? "";
                try
                {
                    return (args == null || args.Length == 0)
                               ? format
                               : string.Format (CultureInfo.InvariantCulture, format, args)
                        ;
                }
                catch (FormatException)
                {
    
                    return format;
                }
            }
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
    
    
    
    
    
    namespace Source.Concurrency
    {
        using System;
        using System.Threading;
    
        sealed partial class AtomicInt32 : IAtomic<Int32>
        {
            Int32 m_value;
    
            public AtomicInt32 (Int32 value = default (Int32))
            {
                m_value = value;
            }
    
            public bool CompareExchange (Int32 newValue, Int32 comparand)
            {
                return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
            }
    
            public Int32 Value
            {
                get { return Interlocked.CompareExchange (ref m_value, default (Int32), default (Int32)); }
            }
    
        }
        sealed partial class AtomicInt64 : IAtomic<Int64>
        {
            Int64 m_value;
    
            public AtomicInt64 (Int64 value = default (Int64))
            {
                m_value = value;
            }
    
            public bool CompareExchange (Int64 newValue, Int64 comparand)
            {
                return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
            }
    
            public Int64 Value
            {
                get { return Interlocked.CompareExchange (ref m_value, default (Int64), default (Int64)); }
            }
    
        }
        sealed partial class AtomicSingle : IAtomic<Single>
        {
            Single m_value;
    
            public AtomicSingle (Single value = default (Single))
            {
                m_value = value;
            }
    
            public bool CompareExchange (Single newValue, Single comparand)
            {
                return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
            }
    
            public Single Value
            {
                get { return Interlocked.CompareExchange (ref m_value, default (Single), default (Single)); }
            }
    
        }
        sealed partial class AtomicDouble : IAtomic<Double>
        {
            Double m_value;
    
            public AtomicDouble (Double value = default (Double))
            {
                m_value = value;
            }
    
            public bool CompareExchange (Double newValue, Double comparand)
            {
                return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
            }
    
            public Double Value
            {
                get { return Interlocked.CompareExchange (ref m_value, default (Double), default (Double)); }
            }
    
        }
    
        partial class Atomic<T> : IAtomic<T>
            where T : class
        {
            T m_value;
    
            public Atomic (T value = null)
            {
                m_value = value;
            }
    
            public bool CompareExchange (T newValue, T comparand)
            {
                return Interlocked.CompareExchange (ref m_value, newValue, comparand) == comparand;
            }
    
            public T Value
            {
                get { return Interlocked.CompareExchange (ref m_value, null, null); }
            }
    
        }
    
    }
    
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    namespace Source.Concurrency
    {
        partial interface IAtomic<T>
        {
            bool CompareExchange (T newValue, T comparand);
            T Value { get; }
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    
    namespace Source.Concurrency
    {
        using System;
        using System.Collections.Concurrent;
        using System.Collections.Generic;
        using System.Threading;
        using System.Threading.Tasks;
    
        using Source.Common;
    
        sealed partial class SequentialTaskScheduler : TaskScheduler, IDisposable
        {
            const int                           DefaultTimeOutInMs = 250;
            public readonly string              Name    ;
            public readonly TimeSpan            TimeOut ;
    
            readonly BlockingCollection<Task>   m_tasks = new BlockingCollection<Task>();
            Thread                              m_executingThread   ;
            bool                                m_done              ;
    
            int                                 m_taskFailureCount;
    
    
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
                Log.Warning ("SequentialTaskScheduler.TryExecuteTaskInline: {0} - Task inline execute not supported", Name);
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
    
            public void ShutDown ()
            {
                if (!m_done)
                {
                    m_done = true;
                    // null task to wake up thread
                    m_tasks.Add (null);                
                }
            }
    
            public void Dispose ()
            {
                var thread = Interlocked.Exchange (ref m_executingThread, null);
                if (thread != null)
                {
                    try
                    {
                        ShutDown ();
                        if (!thread.Join (TimeOut + TimeOut))
                        {
                            Log.Warning (
                                "SequentialTaskScheduler.Dispose: {0} - Executing thread didn't shutdown, aborting it...",
                                Name
                                );
    
                            thread.Abort ();
                            if (!thread.Join (TimeOut))
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
    
    
        
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
    
    
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
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Globalization;
    
        static partial class NumericalExtensions
        {
            // Byte (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_BYTE_NUMERICAL_EXTENSIONS
            public static Byte Min (this Byte left, Byte right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static Byte Max (this Byte left, Byte right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static Byte Clamp (this Byte value, Byte inclusiveMin, Byte inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this Byte value, Byte inclusiveMin, Byte inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out Byte result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Byte Parse (this string s, CultureInfo cultureInfo, Byte defaultValue)
            {
                Byte value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Byte Parse (this string s, Byte defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool IsAnyOn (this Byte value, Byte test)
            {
                return (value & test) != 0;
            }
            
            public static bool IsAnyOff (this Byte value, Byte test)
            {
                return (value & test) != test;
            }
            
            public static bool IsAllOn (this Byte value, Byte test)
            {
                return (value & test) == test;
            }
            
            public static bool IsAllOff (this Byte value, Byte test)
            {
                return (value & test) == 0;
            }
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Byte result)
            {
                return Byte.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_BYTE_NUMERICAL_EXTENSIONS
    
            // Int16 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_INT16_NUMERICAL_EXTENSIONS
            public static Int16 Min (this Int16 left, Int16 right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static Int16 Max (this Int16 left, Int16 right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static Int16 Clamp (this Int16 value, Int16 inclusiveMin, Int16 inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this Int16 value, Int16 inclusiveMin, Int16 inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out Int16 result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Int16 Parse (this string s, CultureInfo cultureInfo, Int16 defaultValue)
            {
                Int16 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int16 Parse (this string s, Int16 defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool IsAnyOn (this Int16 value, Int16 test)
            {
                return (value & test) != 0;
            }
            
            public static bool IsAnyOff (this Int16 value, Int16 test)
            {
                return (value & test) != test;
            }
            
            public static bool IsAllOn (this Int16 value, Int16 test)
            {
                return (value & test) == test;
            }
            
            public static bool IsAllOff (this Int16 value, Int16 test)
            {
                return (value & test) == 0;
            }
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int16 result)
            {
                return Int16.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_INT16_NUMERICAL_EXTENSIONS
    
            // Int32 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_INT32_NUMERICAL_EXTENSIONS
            public static Int32 Min (this Int32 left, Int32 right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static Int32 Max (this Int32 left, Int32 right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static Int32 Clamp (this Int32 value, Int32 inclusiveMin, Int32 inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this Int32 value, Int32 inclusiveMin, Int32 inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out Int32 result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Int32 Parse (this string s, CultureInfo cultureInfo, Int32 defaultValue)
            {
                Int32 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int32 Parse (this string s, Int32 defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool IsAnyOn (this Int32 value, Int32 test)
            {
                return (value & test) != 0;
            }
            
            public static bool IsAnyOff (this Int32 value, Int32 test)
            {
                return (value & test) != test;
            }
            
            public static bool IsAllOn (this Int32 value, Int32 test)
            {
                return (value & test) == test;
            }
            
            public static bool IsAllOff (this Int32 value, Int32 test)
            {
                return (value & test) == 0;
            }
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int32 result)
            {
                return Int32.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_INT32_NUMERICAL_EXTENSIONS
    
            // Int64 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_INT64_NUMERICAL_EXTENSIONS
            public static Int64 Min (this Int64 left, Int64 right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static Int64 Max (this Int64 left, Int64 right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static Int64 Clamp (this Int64 value, Int64 inclusiveMin, Int64 inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this Int64 value, Int64 inclusiveMin, Int64 inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out Int64 result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Int64 Parse (this string s, CultureInfo cultureInfo, Int64 defaultValue)
            {
                Int64 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int64 Parse (this string s, Int64 defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool IsAnyOn (this Int64 value, Int64 test)
            {
                return (value & test) != 0;
            }
            
            public static bool IsAnyOff (this Int64 value, Int64 test)
            {
                return (value & test) != test;
            }
            
            public static bool IsAllOn (this Int64 value, Int64 test)
            {
                return (value & test) == test;
            }
            
            public static bool IsAllOff (this Int64 value, Int64 test)
            {
                return (value & test) == 0;
            }
             
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int64 result)
            {
                return Int64.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_INT64_NUMERICAL_EXTENSIONS
    
            // Single (FloatLike)
    
    #if !T4INCLUDE__SUPPRESS_SINGLE_NUMERICAL_EXTENSIONS
            public static Single Min (this Single left, Single right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static Single Max (this Single left, Single right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static Single Clamp (this Single value, Single inclusiveMin, Single inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this Single value, Single inclusiveMin, Single inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out Single result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Single Parse (this string s, CultureInfo cultureInfo, Single defaultValue)
            {
                Single value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Single Parse (this string s, Single defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static Single Lerp (
                this Single t,
                Single from,
                Single to
                )
            {
                return t.Clamp (0,1) * (to - from) + from;
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Single result)
            {                                                  
                return Single.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_SINGLE_NUMERICAL_EXTENSIONS
    
            // Double (FloatLike)
    
    #if !T4INCLUDE__SUPPRESS_DOUBLE_NUMERICAL_EXTENSIONS
            public static Double Min (this Double left, Double right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static Double Max (this Double left, Double right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static Double Clamp (this Double value, Double inclusiveMin, Double inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this Double value, Double inclusiveMin, Double inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out Double result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Double Parse (this string s, CultureInfo cultureInfo, Double defaultValue)
            {
                Double value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Double Parse (this string s, Double defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static Double Lerp (
                this Double t,
                Double from,
                Double to
                )
            {
                return t.Clamp (0,1) * (to - from) + from;
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Double result)
            {                                                  
                return Double.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_DOUBLE_NUMERICAL_EXTENSIONS
    
            // Decimal (FloatLike)
    
    #if !T4INCLUDE__SUPPRESS_DECIMAL_NUMERICAL_EXTENSIONS
            public static Decimal Min (this Decimal left, Decimal right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static Decimal Max (this Decimal left, Decimal right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static Decimal Clamp (this Decimal value, Decimal inclusiveMin, Decimal inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this Decimal value, Decimal inclusiveMin, Decimal inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out Decimal result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static Decimal Parse (this string s, CultureInfo cultureInfo, Decimal defaultValue)
            {
                Decimal value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Decimal Parse (this string s, Decimal defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static Decimal Lerp (
                this Decimal t,
                Decimal from,
                Decimal to
                )
            {
                return t.Clamp (0,1) * (to - from) + from;
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Decimal result)
            {                                                  
                return Decimal.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_DECIMAL_NUMERICAL_EXTENSIONS
    
            // TimeSpan (TimeSpanLike)
    
    #if !T4INCLUDE__SUPPRESS_TIMESPAN_NUMERICAL_EXTENSIONS
            public static TimeSpan Min (this TimeSpan left, TimeSpan right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static TimeSpan Max (this TimeSpan left, TimeSpan right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static TimeSpan Clamp (this TimeSpan value, TimeSpan inclusiveMin, TimeSpan inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this TimeSpan value, TimeSpan inclusiveMin, TimeSpan inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out TimeSpan result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static TimeSpan Parse (this string s, CultureInfo cultureInfo, TimeSpan defaultValue)
            {
                TimeSpan value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static TimeSpan Parse (this string s, TimeSpan defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out TimeSpan result)
            {                                                  
                return TimeSpan.TryParse (s ?? "", cultureInfo, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_TIMESPAN_NUMERICAL_EXTENSIONS
    
            // DateTime (DateTimeLike)
    
    #if !T4INCLUDE__SUPPRESS_DATETIME_NUMERICAL_EXTENSIONS
            public static DateTime Min (this DateTime left, DateTime right) 
            {
                if (left < right)
                {
                    return left;
                }
            
                return right;
            }
    
            public static DateTime Max (this DateTime left, DateTime right) 
            {
                if (left < right)
                {
                    return right;
                }
            
                return left;
            }
    
            public static DateTime Clamp (this DateTime value, DateTime inclusiveMin, DateTime inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return inclusiveMin;
                }
            
                if (value > inclusiveMax)
                {
                    return inclusiveMax;
                }
    
                return value;
            }
    
            public static bool IsBetween (this DateTime value, DateTime inclusiveMin, DateTime inclusiveMax) 
            {
                if (value < inclusiveMin)
                {
                    return false;
                }
            
                if (value > inclusiveMax)
                {
                    return false;
                }
    
                return true;
            }
    
            public static bool TryParse (this string s, out DateTime result)
            {
                return s.TryParse (CultureInfo.InvariantCulture, out result);
            }
    
            public static DateTime Parse (this string s, CultureInfo cultureInfo, DateTime defaultValue)
            {
                DateTime value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static DateTime Parse (this string s, DateTime defaultValue)
            {
                return s.Parse (CultureInfo.InvariantCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out DateTime result)
            {                                                  
                return DateTime.TryParse (s ?? "", cultureInfo, DateTimeStyles.AssumeLocal, out result);
            }
    
    #endif // T4INCLUDE__SUPPRESS_DATETIME_NUMERICAL_EXTENSIONS
    
        }
    }
    
    
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using System.IO;
        using System.Reflection;
    
        using Source.Common;
    
        static partial class BasicExtensions
        {
            public static bool IsNullOrWhiteSpace (this string v)
            {
                return string.IsNullOrWhiteSpace (v);
            }
    
            public static bool IsNullOrEmpty (this string v)
            {
                return string.IsNullOrEmpty (v);
            }
    
            public static string DefaultTo (this string v, string defaultValue = null)
            {
                return !v.IsNullOrEmpty () ? v : (defaultValue ?? "");
            }
    
            public static IEnumerable<T> DefaultTo<T>(
                this IEnumerable<T> values, 
                IEnumerable<T> defaultValue = null
                )
            {
                return values ?? defaultValue ?? Array<T>.Empty;
            }
    
            public static T[] DefaultTo<T>(this T[] values, T[] defaultValue = null)
            {
                return values ?? defaultValue ?? Array<T>.Empty;
            }
    
            public static T DefaultTo<T>(this T v, T defaultValue = default (T))
                where T : struct, IEquatable<T>
            {
                return !v.Equals (default (T)) ? v : defaultValue;
            }
    
            public static string FormatWith (this string format, CultureInfo cultureInfo, params object[] args)
            {
                return string.Format (cultureInfo, format ?? "", args.DefaultTo ());
            }
    
            public static string FormatWith (this string format, params object[] args)
            {
                return format.FormatWith (CultureInfo.InvariantCulture, args);
            }
    
            public static TValue Lookup<TKey, TValue>(
                this IDictionary<TKey, TValue> dictionary, 
                TKey key, 
                TValue defaultValue = default (TValue))
            {
                if (dictionary == null)
                {
                    return defaultValue;
                }
    
                TValue value;
                return dictionary.TryGetValue (key, out value) ? value : defaultValue;
            }
    
            public static TValue GetOrAdd<TKey, TValue>(
                this IDictionary<TKey, TValue> dictionary, 
                TKey key, 
                TValue defaultValue = default (TValue))
            {
                if (dictionary == null)
                {
                    return defaultValue;
                }
    
                TValue value;
                if (!dictionary.TryGetValue (key, out value))
                {
                    value = defaultValue;
                    dictionary[key] = value;
                }
    
                return value;
            }
    
            public static TValue GetOrAdd<TKey, TValue>(
                this IDictionary<TKey, TValue> dictionary,
                TKey key,
                Func<TValue> valueCreator
                )
            {
                if (dictionary == null)
                {
                    return valueCreator ();
                }
    
                TValue value;
                if (!dictionary.TryGetValue (key, out value))
                {
                    value = valueCreator ();
                    dictionary[key] = value;
                }
    
                return value;
            }
    
            public static void DisposeNoThrow (this IDisposable disposable)
            {
                try
                {
                    if (disposable != null)
                    {
                        disposable.Dispose ();
                    }
                }
                catch (Exception exc)
                {
                    Log.Exception ("DisposeNoThrow: Dispose threw: {0}", exc);
                }
            }
    
            public static TTo CastTo<TTo> (this object value, TTo defaultValue)
            {
                return value is TTo ? (TTo) value : defaultValue;
            }
    
            public static string Concatenate (this IEnumerable<string> values, string delimiter = null, int capacity = 16)
            {
                values = values ?? Array<string>.Empty;
                delimiter = delimiter ?? ", ";
    
                return string.Join(delimiter, values);
            }
    
            public static string GetResourceString (this Assembly assembly, string name, string defaultValue = null)
            {
                defaultValue = defaultValue ?? "";
    
                if (assembly == null)
                {
                    return defaultValue;
                }
    
                var stream = assembly.GetManifestResourceStream(name ?? "");
                if (stream == null)
                {
                    return defaultValue;
                }
    
                using (stream)
                using (var streamReader = new StreamReader (stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
    
            public static IEnumerable<string> ReadLines(this TextReader textReader)
            {
                if (textReader == null)
                {
                    yield break;
                }
    
                string line;
    
                while ((line = textReader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
    
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        using Source.Common;
    
        static partial class EnumerableExtensions
        {
            public static Dictionary<TKey, TValue> ToDictionaryAndResolveDuplicates<T, TKey, TValue>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                Func<T, TValue> valueSelector,
                Func<TValue, T, TValue> duplicateResolver,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                if (keySelector == null) throw new ArgumentNullException ("keySelector");
                if (valueSelector == null) throw new ArgumentNullException ("valueSelector");
                if (duplicateResolver == null) throw new ArgumentNullException ("duplicateResolver");
    
                var dic = new Dictionary<TKey, TValue>(capacity, comparer);
    
                values = values ?? Array<T>.Empty;
    
                foreach (var value in values)
                {
                    var key = keySelector (value);
                    TValue existingValue;
                    if (dic.TryGetValue (key, out existingValue))
                    {
                        var newValue = duplicateResolver (existingValue, value);
                        dic[key] = newValue;
                    }
                    else
                    {
                        var newValue = valueSelector (value);
                        dic[key] = newValue;
                    }
    
                }
    
                return dic;
            }
    
            public static Dictionary<TKey, T> ToDictionaryAndResolveDuplicates<T, TKey>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                Func<T, T, T> duplicateResolver,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                return values.ToDictionaryAndResolveDuplicates (
                    keySelector,
                    v => v,
                    duplicateResolver,
                    capacity,
                    comparer
                    );
            }
    
            public static Dictionary<TKey, TValue> ToDictionaryAndKeepFirst<T, TKey, TValue>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                Func<T, TValue> valueSelector,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                return values.ToDictionaryAndResolveDuplicates (
                    keySelector,
                    valueSelector,
                    (existingValue, newValue) => existingValue,
                    capacity,
                    comparer
                    );
            }
    
            public static Dictionary<TKey, T> ToDictionaryAndKeepFirst<T, TKey>(
                this IEnumerable<T> values,
                Func<T, TKey> keySelector,
                int capacity = 0,
                IEqualityComparer<TKey> comparer = null
                )
            {
                return values.ToDictionaryAndKeepFirst (
                    keySelector,
                    v => v,
                    capacity,
                    comparer
                    );
            }
    
            public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
            {
                values = values ?? Array<T>.Empty;
    
                return new HashSet<T>(values, comparer);
            }
    
            sealed partial class SelectorEqualityComparer<T, TKey> : IEqualityComparer<T>
            {
                static readonly IEqualityComparer<TKey> s_defaultComparer = EqualityComparer<TKey>.Default;
    
                readonly Func<T, TKey> m_selector;
    
                public SelectorEqualityComparer (Func<T, TKey> selector)
                {
                    System.Diagnostics.Debug.Assert (selector != null);
                    m_selector = selector;
                }
    
                public bool Equals (T x, T y)
                {
                    return s_defaultComparer.Equals (m_selector (x), m_selector (y));
                }
    
                public int GetHashCode (T obj)
                {
                    return s_defaultComparer.GetHashCode (m_selector (obj));
                }
    
            }
    
            public static IEnumerable<T> Distinct<T, TKey> (
                this IEnumerable<T> values, 
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
    
                return values.Distinct (new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static IEnumerable<T> Union<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.Union (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static IEnumerable<T> Intersect<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.Intersect (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static IEnumerable<T> Except<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.Except (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
            public static bool SequenceEqual<T, TKey>(
                this IEnumerable<T> values,
                IEnumerable<T> otherValue,
                Func<T, TKey> selector)
            {
                if (selector == null) throw new ArgumentNullException ("selector");
    
                values = values ?? Array<T>.Empty;
                otherValue = otherValue ?? Array<T>.Empty;
    
                return values.SequenceEqual (otherValue, new SelectorEqualityComparer<T, TKey>(selector));
            }
    
        }
    }
}

// ############################################################################
namespace ProjectInclude
{
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
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Windows.Threading;
        using System.Windows;
        using System.Windows.Data;
    
        using Source.Common;
    
        static partial class WpfExtensions
        {
            public static void Async_Invoke (
                this Dispatcher dispatcher, 
                string actionName, 
                Action action
                )
            {
                if (action == null)
                {
                    return;
                }
    
                Action act = () =>
                                 {
    #if DEBUG
                                     Log.Info ("Async_Invoke: {0}", actionName ?? "Unknown");
    #endif
    
                                     try
                                     {
                                         action ();
                                     }
                                     catch (Exception exc)
                                     {
                                         Log.Exception ("Async_Invoke: Caught exception: {0}", exc);
                                     }
                                 };
    
                dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
                dispatcher.BeginInvoke (DispatcherPriority.ApplicationIdle, act);
            }
    
            public static void Async_Invoke (
                this DependencyObject dependencyObject, 
                string actionName, 
                Action action
                )
            {
                var dispatcher = dependencyObject == null ? Dispatcher.CurrentDispatcher : dependencyObject.Dispatcher;
    
                dispatcher.Async_Invoke (actionName, action);
            }
    
            public static BindingBase GetBindingOf (
                this DependencyObject dependencyObject, 
                DependencyProperty dependencyProperty 
                )
            {
                if (dependencyObject == null)
                {
                    return null;
                }
    
                if (dependencyProperty == null)
                {
                    return null;
                }
    
                return BindingOperations.GetBindingBase (dependencyObject, dependencyProperty);
            }
    
            public static bool IsBoundTo (
                this DependencyObject dependencyObject, 
                DependencyProperty dependencyProperty 
                )
            {
                if (dependencyObject == null)
                {
                    return false;
                }
    
                if (dependencyProperty == null)
                {
                    return false;
                }
    
                return BindingOperations.IsDataBound (dependencyObject, dependencyProperty);
            }
    
            public static void ResetBindingOf (
                this DependencyObject dependencyObject, 
                DependencyProperty dependencyProperty, 
                BindingBase binding = null
                )
            {
                if (dependencyObject == null)
                {
                    return;
                }
    
                if (dependencyProperty == null)
                {
                    return;
                }
    
                BindingOperations.ClearBinding (dependencyObject, dependencyProperty);
    
                if (binding != null)
                {
                    BindingOperations.SetBinding (dependencyObject, dependencyProperty, binding);
                }
            }
        }
    }
}
// ############################################################################

// ############################################################################
namespace ProjectInclude.Include
{
    static partial class MetaData
    {
        public const string RootPath        = @"C:\temp\GitHub\T4Include\NonSource\Tests\Test_Functionality\..\..\..";
        public const string IncludeDate     = @"2012-11-04T19:46:43";

        public const string Include_0       = @"C:\temp\GitHub\T4Include\Common\Array.cs";
        public const string Include_1       = @"C:\temp\GitHub\T4Include\Common\BaseDisposable.cs";
        public const string Include_2       = @"C:\temp\GitHub\T4Include\Common\ConsoleLog.cs";
        public const string Include_3       = @"C:\temp\GitHub\T4Include\Common\Generated_Log.cs";
        public const string Include_4       = @"C:\temp\GitHub\T4Include\Common\HRON.cs";
        public const string Include_5       = @"C:\temp\GitHub\T4Include\Common\Log.cs";
        public const string Include_6       = @"C:\temp\GitHub\T4Include\Concurrency\Atomic.cs";
        public const string Include_7       = @"C:\temp\GitHub\T4Include\Concurrency\IAtomic.cs";
        public const string Include_8       = @"C:\temp\GitHub\T4Include\Concurrency\TaskSchedulers.cs";
        public const string Include_9       = @"C:\temp\GitHub\T4Include\Extensions\NumericalExtensions.cs";
        public const string Include_10       = @"C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs";
        public const string Include_11       = @"C:\temp\GitHub\T4Include\Extensions\EnumerableExtensions.cs";
        public const string Include_12       = @"C:\temp\GitHub\T4Include\Extensions\WpfExtensions.cs";
    }
}
// ############################################################################




