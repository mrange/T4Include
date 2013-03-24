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

// ### INCLUDE: ../Common/Array.cs
// ### INCLUDE: ../Common/Config.cs
// ### INCLUDE: ../Common/SubString.cs

// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel


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
