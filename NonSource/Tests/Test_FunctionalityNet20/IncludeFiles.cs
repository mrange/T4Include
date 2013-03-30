
// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # text template file (.tt)                                                 #
// ############################################################################



// ############################################################################
// @@@ INCLUDING: C:\temp\GitHub\T4Include\HRON\HRONSerializer.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDE_FOUND: ../Common/Config.cs
// @@@ INCLUDE_FOUND: ../Common/SubString.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\NET20\Common.cs
// @@@ INCLUDE_FOUND: Generated_Common.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\SubString.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\NET20\Generated_Common.cs
// ############################################################################
// Certains directives such as #define and // Resharper comments has to be 
// moved to top in order to work properly    
// ############################################################################
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\HRON\HRONSerializer.cs
namespace FileInclude
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
    
    
    
    
    namespace Source.HRON
    {
        using System.Collections.Generic;
        using System.Text;
        using Source.Common;
    
        partial interface IHRONVisitor
        {
            void Document_Begin ();
            void Document_End ();
            void PreProcessor (SubString line);
            void Empty (SubString line);
    
            void Comment(int indent, SubString comment);
    
            void Value_Begin(SubString name);
            void Value_Line(SubString value);
            void Value_End(SubString name);
    
            void Object_Begin(SubString name);
            void Object_End(SubString name);
    
            void Error(int lineNo, SubString line, HRONSerializer.ParseError parseError);
        }
    
        abstract partial class BaseHRONWriterVisitor : IHRONVisitor
        {
            readonly    StringBuilder   m_sb    = new StringBuilder();
            bool                        m_first = true  ;
            int                         m_indent        ;
    
            protected abstract void Write       (StringBuilder line);
            protected abstract void WriteLine   ();
            void                    WriteLine   (StringBuilder line)
            {
                if (m_first)
                {
                    m_first = false;
                }
                else
                {
                    WriteLine ();
                }
    
                Write (line);
            }
    
            public abstract void Document_Begin();
            public abstract void Document_End();
    
            public void PreProcessor(SubString line)
            {
                m_sb.Remove(0, m_sb.Length);
                m_sb.Append('!');
                m_sb.AppendSubString(line);
                WriteLine(m_sb);
            }
    
            public void Empty (SubString line)
            {
                m_sb.Remove(0, m_sb.Length);
                m_sb.AppendSubString(line);
                WriteLine(m_sb);
            }
    
            public void Comment(int indent, SubString comment)
            {
                m_sb.Remove(0, m_sb.Length);
                m_sb.Append('\t', indent);
                m_sb.Append('#');
                m_sb.AppendSubString(comment);
                WriteLine(m_sb);
            }
    
            public void Value_Begin(SubString name)
            {
                m_sb.Remove(0, m_sb.Length);
                m_sb.Append('\t', m_indent);
                m_sb.Append('=');
                m_sb.Append(name);
                ++m_indent;
                WriteLine(m_sb);
            }
    
            public void Value_Line(SubString value)
            {
                m_sb.Remove(0, m_sb.Length);
                m_sb.Append('\t', m_indent);
                m_sb.AppendSubString(value);
                WriteLine(m_sb);
            }
    
            public void Value_End(SubString name)
            {
                --m_indent;
            }
    
            public void Object_Begin(SubString name)
            {
                m_sb.Remove(0, m_sb.Length);
                m_sb.Append('\t', m_indent);
                m_sb.Append('@');
                m_sb.AppendSubString(name);
                WriteLine(m_sb);
                ++m_indent;
            }
    
            public void Object_End(SubString name)
            {
                --m_indent;
            }
    
            public void Error(int lineNo, SubString line, HRONSerializer.ParseError parseError)
            {
                m_sb.Remove(0, m_sb.Length);
                m_sb.AppendFormat(Config.DefaultCulture, "# Error at line {0}: {1}", lineNo, parseError);
                WriteLine(m_sb);
            }
    
        }
    
        sealed partial class HRONWriterVisitor : BaseHRONWriterVisitor
        {
            readonly StringBuilder m_sb = new StringBuilder(128);
    
            public string Value
            {
                get
                {
                    return m_sb.ToString();                
                }
            }
    
            protected override void Write(StringBuilder line)
            {
                m_sb.Append(line.ToString());
            }
    
            protected override void WriteLine()
            {
                m_sb.AppendLine();
            }
    
            public override void Document_Begin()
            {
            }
    
            public override void Document_End()
            {
            }
        }
    
        static partial class HRONSerializer
        {
            enum ParseState
            {
                ExpectingTag    ,
                ExpectingValue  ,
            }
    
            public enum ParseError
            {
                ProgrammingError                ,
                IndentIncreasedMoreThanExpected ,
                TagIsNotCorrectlyFormatted      ,
            }
    
            public static void Parse(
                int maxErrorCount,
                IEnumerable<SubString> lines,
                IHRONVisitor visitor
                )
            {
                if (visitor == null)
                {
                    return;
                }
    
                visitor.Document_Begin();
    
                try
                {
                    var errorCount = 0;
    
                    lines = lines ?? Array<SubString>.Empty;
    
                    var state = ParseState.ExpectingTag;
                    var expectedIndent = 0;
                    var lineNo = 0;
                    var context = new Stack<SubString>();
    
                    var acceptsPreProcessor = true;
    
                    foreach (var line in lines)
                    {
                        ++lineNo;
    
                        var lineLength = line.Length;
                        var begin = line.Begin;
                        var end = line.End;
    
                        var currentIndent = 0;
                        var baseString = line.BaseString;
    
                        if (acceptsPreProcessor)
                        {
                            if (lineLength > 0 && baseString[begin] == '!')
                            {
                                visitor.PreProcessor(line.ToSubString(1));
                                continue;
                            }
                            else
                            {
                                acceptsPreProcessor = false;
                            }
                        }
    
                        for (var iter = begin; iter < end; ++iter)
                        {
                            var ch = baseString[iter];
                            if (ch == '\t')
                            {
                                ++currentIndent;
                            }
                            else
                            {
                                break;
                            }
                        }
    
                        bool isComment;
                        switch (state)
                        {
                            case ParseState.ExpectingTag:
                                isComment = currentIndent < lineLength
                                            && baseString[currentIndent + begin] == '#'
                                    ;
                                break;
                            case ParseState.ExpectingValue:
                            default:
                                isComment = currentIndent < expectedIndent
                                            && currentIndent < lineLength
                                            && baseString[currentIndent + begin] == '#'
                                    ;
                                break;
                        }
    
                        var isWhiteSpace = line.ToSubString(currentIndent).IsWhiteSpace;
    
                        if (isComment)
                        {
                            visitor.Comment(currentIndent, line.ToSubString(currentIndent + 1));
                        }
                        else if (isWhiteSpace && currentIndent < expectedIndent)
                        {
                            switch (state)
                            {
                                case ParseState.ExpectingValue:
                                    visitor.Value_Line(SubString.Empty);
                                    break;
                                case ParseState.ExpectingTag:
                                default:
                                    visitor.Empty(line);
                                    break;
                            }
                        }
                        else if (isWhiteSpace)
                        {
                            switch (state)
                            {
                                case ParseState.ExpectingValue:
                                    visitor.Value_Line(line.ToSubString(expectedIndent));
                                    break;
                                case ParseState.ExpectingTag:
                                default:
                                    visitor.Empty(line);
                                    break;
                            }
                        }
                        else
                        {
                            if (currentIndent < expectedIndent)
                            {
                                switch (state)
                                {
                                    case ParseState.ExpectingTag:
                                        for (var iter = currentIndent; iter < expectedIndent; ++iter)
                                        {
                                            visitor.Object_End(context.Peek());
                                            context.Pop();
                                        }
                                        break;
                                    case ParseState.ExpectingValue:
                                    default:
                                        visitor.Value_End(context.Peek());
                                        // Popping the value name
                                        context.Pop();
                                        for (var iter = currentIndent + 1; iter < expectedIndent; ++iter)
                                        {
                                            visitor.Object_End(context.Peek());
                                            context.Pop();
                                        }
                                        break;
                                }
    
                                expectedIndent = currentIndent;
                                state = ParseState.ExpectingTag;
                            }
    
                            switch (state)
                            {
                                case ParseState.ExpectingTag:
                                    if (currentIndent > expectedIndent)
                                    {
                                        visitor.Error(lineNo, line, ParseError.IndentIncreasedMoreThanExpected);
                                        if (++errorCount > 0)
                                        {
                                            return;
                                        }
                                    }
                                    else if (currentIndent < lineLength)
                                    {
                                        var first = baseString[currentIndent + begin];
                                        switch (first)
                                        {
                                            case '@':
                                                state = ParseState.ExpectingTag;
                                                ++expectedIndent;
                                                context.Push(line.ToSubString(currentIndent + 1));
                                                visitor.Object_Begin(context.Peek());
                                                break;
                                            case '=':
                                                state = ParseState.ExpectingValue;
                                                ++expectedIndent;
                                                context.Push(line.ToSubString(currentIndent + 1));
                                                visitor.Value_Begin(context.Peek());
                                                break;
                                            default:
                                                visitor.Error(lineNo, line, ParseError.TagIsNotCorrectlyFormatted);
                                                if (++errorCount > 0)
                                                {
                                                    return;
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        visitor.Error(lineNo, line, ParseError.ProgrammingError);
                                        if (++errorCount > 0)
                                        {
                                            return;
                                        }
                                    }
                                    break;
                                case ParseState.ExpectingValue:
                                    visitor.Value_Line(line.ToSubString(expectedIndent));
                                    break;
                            }
                        }
                    }
    
                    switch (state)
                    {
                        case ParseState.ExpectingTag:
                            for (var iter = 0; iter < expectedIndent; ++iter)
                            {
                                visitor.Object_End(context.Peek());
                                context.Pop();
                            }
                            break;
                        case ParseState.ExpectingValue:
                        default:
                            visitor.Value_End(context.Peek());
                            // Popping the value name
                            context.Pop();
                            for (var iter = 0 + 1; iter < expectedIndent; ++iter)
                            {
                                visitor.Object_End(context.Peek());
                                context.Pop();
                            }
                            break;
                    }
    
                }
                finally
                {
                    visitor.Document_End();
                }
            }
        }
    
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\HRON\HRONSerializer.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\NET20\Common.cs
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


namespace System.Runtime.CompilerServices
{
    using System;

    sealed class ExtensionAttribute : Attribute
    {

    }
}

// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\NET20\Common.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Array.cs
namespace FileInclude
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
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Array.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Config.cs
namespace FileInclude
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
        using System.Globalization;
    
        sealed partial class InitConfig
        {
            public CultureInfo DefaultCulture = CultureInfo.InvariantCulture;
        }
    
        static partial class Config
        {
            static partial void Partial_Constructed(ref InitConfig initConfig);
    
            public readonly static CultureInfo DefaultCulture;
    
            static Config ()
            {
                var initConfig = new InitConfig();
    
                Partial_Constructed (ref initConfig);
    
                initConfig = initConfig ?? new InitConfig();
    
                DefaultCulture = initConfig.DefaultCulture;
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Config.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\SubString.cs
namespace FileInclude
{
    // ----------------------------------------------------------------------------------------------
    // Copyright (c) M�rten R�nge.
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
        using System.Collections;
        using System.Collections.Generic;
        using System.Text;
    
    
        static class SubStringExtensions
        {
            public static void AppendSubString (this StringBuilder sb, SubString ss)
            {
                sb.Append(ss.BaseString, ss.Begin, ss.Length);
            }
    
            public static string Concatenate (this IEnumerable<SubString> values, string delimiter = null)
            {
                if (values == null)
                {
                    return "";
                }
    
                delimiter = delimiter ?? ", ";
    
                var first = true;
    
                var sb = new StringBuilder();
                foreach (var value in values)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append(delimiter);
                    }
    
                    sb.AppendSubString(value);
                }
    
                return sb.ToString();
            }
    
    
    
            public static SubString ToSubString (this string value, int begin = 0, int count = int.MaxValue / 2)
            {
                return new SubString(value, begin, count);
            }
    
            public static SubString ToSubString(this StringBuilder value, int begin = 0, int count = int.MaxValue / 2)
            {
                return new SubString(value.ToString(), begin, count);
            }
    
            public static SubString ToSubString(this SubString value, int begin = 0, int count = int.MaxValue / 2)
            {
                return new SubString(value, begin, count);
            }
    
            enum ParseLineState
            {
                NewLine     ,
                Inline      ,
                ConsumedCR  ,
            }
    
            public static IEnumerable<SubString> ReadLines(this string value)
            {
                return value.ToSubString().ReadLines();
            }
    
            public static IEnumerable<SubString> ReadLines (this SubString subString)
            {
                var baseString = subString.BaseString;
                var begin = subString.Begin;
                var end = subString.End;
    
                var beginLine   = begin ;
                var count       = 0     ;
    
                var state       = ParseLineState.NewLine;
    
                for (var iter = begin; iter < end; ++iter)
                {
                    var ch = baseString[iter];
    
                    switch (state)
                    {
                        case ParseLineState.ConsumedCR:
                            yield return new SubString(baseString, beginLine, count);
                            switch (ch)
                            {
                                case '\r':
                                    beginLine = iter;
                                    count = 0;
                                    state = ParseLineState.ConsumedCR;
                                    break;
                                case '\n':
                                    state = ParseLineState.NewLine;
                                    break;
                                default:
                                    beginLine = iter;
                                    count = 1;
                                    state = ParseLineState.Inline;
                                    break;
                            }
    
                            break;
                        case ParseLineState.NewLine:
                            beginLine   = iter;
                            count       = 0;
                            switch (ch)
                            {
                                case '\r':
                                    state = ParseLineState.ConsumedCR;
                                    break;
                                case '\n':
                                    yield return new SubString(baseString, beginLine, count);
                                    state = ParseLineState.NewLine;
                                    break;
                                default:
                                    state = ParseLineState.Inline;
                                    ++count;
                                    break;
                            }
                            break;
                        case ParseLineState.Inline:
                        default:
                            switch (ch)
                            {
                                case '\r':
                                    state = ParseLineState.ConsumedCR;
                                    break;
                                case '\n':
                                    yield return new SubString(baseString, beginLine, count);
                                    state = ParseLineState.NewLine;
                                    break;
                                default:
                                    ++count;
                                    break;
                            }
                            break;
                    }
                }
    
                switch (state)
                {
                    case ParseLineState.NewLine:
                        yield return new SubString(baseString, 0, 0);
                        break;
                    case ParseLineState.ConsumedCR:
                        yield return new SubString(baseString, beginLine, count);
                        yield return new SubString(baseString, 0, 0);
                        break;
                    case ParseLineState.Inline:
                    default:
                        yield return new SubString(baseString, beginLine, count);
                        break;
                }
            }
    
        }
    
        struct SubString 
            :   IComparable
            ,   ICloneable
            ,   IComparable<SubString>
            ,   IEnumerable<char>
            ,   IEquatable<SubString>
        {
            readonly string m_baseString;
            readonly int m_begin;
            readonly int m_end;
    
            string m_value;
            int m_hashCode;
            bool m_hasHashCode;
    
            static int Clamp (int v, int l, int r)
            {
                if (v < l)
                {
                    return l;
                }
    
                if (r < v)
                {
                    return r;
                }
    
                return v;
            }
    
            public static readonly SubString Empty = new SubString(null, 0,0);
    
            public SubString(SubString subString, int begin, int count) : this()
            {
                m_baseString    = subString.BaseString;
                var length      = subString.Length;
    
                begin           = Clamp(begin, 0, length);
                count           = Clamp(count, 0, length - begin);
                var end         = begin + count;
    
                m_begin         = subString.Begin + begin;
                m_end           = subString.Begin + end;
            }
    
            public SubString(string baseString, int begin, int count) : this()
            {
                m_baseString    = baseString;
                var length      = BaseString.Length;
    
                begin           = Clamp(begin, 0, length);
                count           = Clamp(count, 0, length - begin);
                var end         = begin + count;
    
                m_begin         = begin;
                m_end           = end;
            }
    
            public bool Equals(SubString other)
            {
                return CompareTo(other) == 0;
            }
    
            public override int GetHashCode()
            {
                if (!m_hasHashCode)
                {
                    m_hashCode = Value.GetHashCode();
                    m_hasHashCode = true;
                }
    
                return m_hashCode;
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            public object Clone()
            {
                return this;
            }
    
            public int CompareTo(object obj)
            {
                return obj is SubString ? CompareTo((SubString) obj) : 1;
            }
    
    
            public override bool Equals(object obj)
            {
                return obj is SubString && Equals((SubString) obj);
            }
    
    
            public int CompareTo(SubString other)
            {
                return String.Compare(
                    BaseString,
                    Begin,
                    other.BaseString,
                    other.Begin,
                    Math.Min(Length, other.Length)
                    );
            }
    
            public IEnumerator<char> GetEnumerator()
            {
                for (var iter = Begin; iter < End; ++iter)
                {
                    yield return BaseString[iter];
                }
            }
    
            public override string ToString()
            {
                return Value;
            }
    
            public string Value
            {
                get
                {
                    if (m_value == null)
                    {
                        m_value = BaseString.Substring(Begin, Length);
                    }
                    return m_value;
                }
            }
    
            public string BaseString
            {
                get { return m_baseString ?? ""; }
            }
    
            public int Begin
            {
                get { return m_begin; }
            }
    
            public int End
            {
                get { return m_end; }
            }
    
            public char this[int idx]
            {
                get
                {
                    if (idx < 0)
                    {
                        throw new IndexOutOfRangeException("idx");
                    }
    
                    if (idx >= Length)
                    {
                        throw new IndexOutOfRangeException("idx");
                    }
    
                    return BaseString[idx + Begin];
                }
            }
    
            public int Length
            {
                get { return End - Begin; }
            }
    
            public bool IsEmpty
            {
                get { return Length == 0; }
            }
    
            public bool IsWhiteSpace
            {
                get
                {
                    if (IsEmpty)
                    {
                        return true;
                    }
    
                    for(var iter = Begin; iter < End; ++iter)
                    {
                        if (!Char.IsWhiteSpace(BaseString[iter]))
                        {
                            return false;
                        }
                    }
    
                    return true;
                }
            }
    
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\SubString.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\NET20\Generated_Common.cs
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






namespace System
{
    public delegate TResult Func<out TResult> ();
    public delegate TResult Func<in T0, out TResult> (T0 v0);

    public delegate void Action<
            in T0
        ,   in T1   
        > (
            T0 v0
        ,   T1 v1  
        );

    public delegate TResult Func<
            in T0
        ,   in T1   
        ,   out TResult
        > (
            T0 v0
        ,   T1 v1  
        );

    public delegate void Action<
            in T0
        ,   in T1   
        ,   in T2   
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        );

    public delegate TResult Func<
            in T0
        ,   in T1   
        ,   in T2   
        ,   out TResult
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        );

    public delegate void Action<
            in T0
        ,   in T1   
        ,   in T2   
        ,   in T3   
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        ,   T3 v3  
        );

    public delegate TResult Func<
            in T0
        ,   in T1   
        ,   in T2   
        ,   in T3   
        ,   out TResult
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        ,   T3 v3  
        );


}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\NET20\Generated_Common.cs
// ############################################################################

// ############################################################################
namespace FileInclude.Include
{
    static partial class MetaData
    {
        public const string RootPath        = @"..\..\..";
        public const string IncludeDate     = @"2013-03-30T10:16:06";

        public const string Include_0       = @"C:\temp\GitHub\T4Include\HRON\HRONSerializer.cs";
        public const string Include_1       = @"C:\temp\GitHub\T4Include\NET20\Common.cs";
        public const string Include_2       = @"C:\temp\GitHub\T4Include\Common\Array.cs";
        public const string Include_3       = @"C:\temp\GitHub\T4Include\Common\Config.cs";
        public const string Include_4       = @"C:\temp\GitHub\T4Include\Common\SubString.cs";
        public const string Include_5       = @"C:\temp\GitHub\T4Include\NET20\Generated_Common.cs";
    }
}
// ############################################################################


