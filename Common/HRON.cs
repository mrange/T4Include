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

// ### INCLUDE: Array.cs
// ### INCLUDE: SubString.cs

// ReSharper disable InconsistentNaming
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
                get { return m_value ?? HRONValue.Empty; }
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
        public static readonly HRONValue Empty = new HRONValue("");

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

    partial interface IHRONParseVisitor
    {
        void Comment(SubString comment);

        void Value_Begin(SubString name);
        void Value_Line(SubString value);
        void Value_End(SubString name);

        void Object_Begin(SubString name);
        void Object_End(SubString name);

        void Error(int lineNo, SubString line, HRON.ParseError parseError);
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
        }

        public enum ParseError
        {
            IndentIncreasedMoreThanExpected,
            TagIsNotCorrectlyFormatted,
            TrailingNonWhiteSpaceAfterTag
        }

        sealed partial class BuildObjectVisitor : IHRONParseVisitor
        {
            public struct Item
            {
                public readonly SubString Name;
                public readonly List<HRONObject.Pair> Pairs;

                public Item (SubString name): this()
                {
                    Name = name;
                    Pairs = new List<HRONObject.Pair>();
                }
            }
          
            readonly Stack<Item> m_stack = new Stack<Item>();
            readonly StringBuilder m_value = new StringBuilder(128);
            bool m_firstLine = true;

            public readonly List<HRONParseError> Errors = new List<HRONParseError>();
            public readonly int MaxErrors;

            public BuildObjectVisitor (int maxErrors)
            {
                MaxErrors = maxErrors;
                m_stack.Push(new Item("Root".ToSubString()));
            }

            public Item Top
            {
                get { return m_stack.Peek(); }
            }

            public void Comment(SubString comment)
            {
            }

            public void Value_Begin(SubString name)
            {
                m_value.Clear();
                m_firstLine = true;
            }

            public void Value_Line(SubString value)
            {
                if (m_firstLine)
                {
                    m_firstLine = false;
                }
                else
                {
                    m_value.AppendLine();
                }
                m_value.Append(value);
            }

            public void Value_End(SubString name)
            {
                AddEntity(name.Value, new HRONValue(m_value.ToString()));
            }

            public void Object_Begin(SubString name)
            {
                m_stack.Push(new Item(name));
            }

            public void Object_End(SubString name)
            {
                var pop = m_stack.Pop();
                AddEntity(pop.Name.Value, new HRONObject (pop.Pairs.ToArray()));
            }

            void AddEntity(string name, IHRONEntity entity)
            {
                m_stack.Peek().Pairs.Add(new HRONObject.Pair(name, entity));
            }

            public void Error(int lineNo, SubString line, ParseError parseError)
            {
                Errors.Add(new HRONParseError(lineNo, line.Value, parseError));
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

            hronObject = new HRONObject(visitor.Top.Pairs.ToArray());

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
            var expectedIndent = 0;
            var lineNo = 0;
            var sb = new StringBuilder(80);
            var context = new Stack<SubString>();

            foreach (var l in lines)
            {
                ++lineNo;
                var line = l.ToSubString();

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
                    visitor.Comment(line.ToSubString(currentIndent + 1));
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
                            var existingIndention = expectedIndent;
                            sb.Clear();
                            for (var iter = currentIndent; iter < lineLength; ++iter)
                            {
                                var ch = line[iter];
                                switch (ch)
                                {
                                    case ':':
                                        state = ParseState.ExpectingTag;
                                        ++expectedIndent;
                                        iter = lineLength;
                                        context.Push(sb.ToSubString());
                                        visitor.Object_Begin(context.Peek());
                                        break;
                                    case '=':
                                        state = ParseState.ExpectingValue;
                                        ++expectedIndent;
                                        iter = lineLength;
                                        context.Push(sb.ToSubString());
                                        visitor.Value_Begin(context.Peek());
                                        break;
                                    default:
                                        sb.Append(ch);
                                        break;
                                }

                            }

                            if (existingIndention == expectedIndent)
                            {
                                visitor.Error(lineNo, line, ParseError.TagIsNotCorrectlyFormatted);
                            }

                            if (!line.ToSubString(currentIndent + sb.Length + 1).IsWhiteSpace)
                            {
                                visitor.Error(lineNo, line, ParseError.TrailingNonWhiteSpaceAfterTag);                                
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
