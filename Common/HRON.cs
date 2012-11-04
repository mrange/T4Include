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
