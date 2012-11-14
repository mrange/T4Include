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
        readonly StringBuilder m_sb = new StringBuilder();
        int m_indent;
        
        protected abstract void WriteLine (string line);
        protected abstract void WriteLine (StringBuilder line);

        public void Empty (SubString line)
        {
            m_sb.Clear();
            m_sb.AppendSubString(line);
            WriteLine(m_sb);
        }

        public void Comment(int indent, SubString comment)
        {
            m_sb.Clear();
            m_sb.Append('\t', indent);
            m_sb.Append('#');
            m_sb.AppendSubString(comment);
            WriteLine(m_sb);
        }

        public void Value_Begin(SubString name)
        {
            m_sb.Clear();
            m_sb.Append('\t', m_indent);
            m_sb.Append('=');
            m_sb.Append(name);
            ++m_indent;
            WriteLine(m_sb);
        }

        public void Value_Line(SubString value)
        {
            m_sb.Clear();
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
            m_sb.Clear();
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
            m_sb.Clear();
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

        protected override void WriteLine(string line)
        {
            m_sb.AppendLine(line);
        }

        protected override void WriteLine(StringBuilder line)
        {
            var count = line.Length;
            for (var iter = 0; iter < count; ++iter)
            {
                m_sb.Append(line[iter]);
            }
            m_sb.AppendLine();
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
            IndentIncreasedMoreThanExpected ,
            TagIsNotCorrectlyFormatted      ,
        }

        public static void Parse (
            int maxErrorCount,
            IEnumerable<SubString> lines,
            IHRONVisitor visitor
            )
        {
            if (visitor == null)
            {
                return;
            }

            var errorCount = 0;

            lines = lines ?? Array<SubString>.Empty;

            var state = ParseState.ExpectingTag;
            var expectedIndent = 0;
            var lineNo = 0;
            var context = new Stack<SubString>();

            foreach (var line in lines)
            {
                ++lineNo;

                var currentIndent = 0;
                var lineLength = line.Length;

                for (var iter = 0; iter < lineLength; ++iter)
                {
                    var ch = line[iter];
                    if (ch == '\t')
                    {
                        ++currentIndent;
                    }
                    else
                    {
                        iter = lineLength;
                    }
                }

                if (currentIndent > expectedIndent)
                {
                    visitor.Error(lineNo, line, ParseError.IndentIncreasedMoreThanExpected);
                    if (++errorCount > 0)
                    {
                        return;
                    }
                    continue;
                }

                bool isComment;
                switch (state)
                {
                    case ParseState.ExpectingTag:
                        isComment = currentIndent < lineLength
                            && line[currentIndent] == '#'
                            ;
                        break;
                    case ParseState.ExpectingValue:
                    default:
                        isComment = currentIndent < expectedIndent
                            && currentIndent < lineLength
                            && line[currentIndent] == '#'
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
                            if (currentIndent < lineLength)
                            {
                                var first = line[currentIndent];
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

    }

}
