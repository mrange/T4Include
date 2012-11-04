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

// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel

namespace Source.Common
{
    using System.Collections.Generic;
    using System.Text;

    partial class HRONParseError
    {
        public readonly int LineNo;
        public readonly string Line;
        public readonly string Message;

        public HRONParseError(int lineNo, string line, string message)
        {
            LineNo = lineNo;
            Line = line;
            Message = message;
        }
    }

    partial interface IHRONEntity
    {
        HRON.Type Type { get; }
    }

    sealed partial class HRONObject : IHRONEntity
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
        }

        public readonly Pair[] Pairs;

        public HRONObject(Pair[] pairs)
        {
            Pairs = pairs ?? Array<Pair>.Empty;
        }

        public HRON.Type Type
        {
            get { return HRON.Type.Object; }
        }
    }

    sealed partial class HRONValue : IHRONEntity
    {
        public readonly string Value;

        public HRONValue(string value)
        {
            Value = value ?? "";
        }

        public HRON.Type Type
        {
            get { return HRON.Type.Value; }
        }

    }

    sealed partial class HRONComment : IHRONEntity
    {
        public readonly string Comment;

        public HRONComment(string comment)
        {
            Comment = comment ?? "";
        }

        public HRON.Type Type
        {
            get { return HRON.Type.Comment; }
        }
    }

    sealed partial class HRONEmpty : IHRONEntity
    {
        public static readonly HRONEmpty DefaultValue = new HRONEmpty();

        public HRON.Type Type
        {
            get { return HRON.Type.Empty; }
        }
    }

    partial interface IHRONParseVisitor
    {
        void Empty();
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
                    visitor.Empty();
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
