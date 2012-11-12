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
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel

// ### INCLUDE: HRONSerializer.cs

using System.Dynamic;
using System.Linq;

namespace Source.HRON
{
    using System.Collections.Generic;
    using System.Text;
    using Source.Common;

    partial class HRONDynamicParseError
    {
        public readonly int LineNo;
        public readonly string Line;
        public readonly HRONSerializer.ParseError ParseError;

        public HRONDynamicParseError(int lineNo, string line, HRONSerializer.ParseError parseError)
        {
            LineNo = lineNo;
            Line = line;
            ParseError = parseError;
        }
    }

    partial interface IHRONEntity
    {
        HRONSerializer.Type Type { get; }

        IEnumerable<IHRONEntity> this[string name] { get; }
        string Value { get; }

        void Apply(SubString name, IHRONVisitor visitor);
        void ToString(StringBuilder sb);
    }
    
    sealed partial class HRONObject : IHRONEntity
    {
        public partial struct Pair
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

        ILookup<string, IHRONEntity> m_lookup;
        readonly Pair[] m_pairs;

        public HRONObject(Pair[] pairs)
        {
            m_pairs = pairs ?? Array<Pair>.Empty;
        }

        public Pair[] GetPairs ()
        {
            return m_pairs;
        }

        ILookup<string, IHRONEntity> GetLookup()
        {
            if (m_lookup == null)
            {
                m_lookup = m_pairs.ToLookup(p => p.Name, p => p.Value);
            }

            return m_lookup;
        }

        public HRONSerializer.Type Type
        {
            get { return HRONSerializer.Type.Object; }
        }

        public IEnumerable<IHRONEntity> this[string name]
        {
            get { return GetLookup()[name ?? ""]; }
        }

        public string Value
        {
            get { return ""; }
        }

        public void Visit (IHRONVisitor visitor)
        {
            if (visitor == null)
            {
                return;
            }

            for (var index = 0; index < m_pairs.Length; index++)
            {
                var pair = m_pairs[index];
                var innerName = pair.Name.ToSubString();
                pair.Value.Apply(innerName, visitor);
            }
        }

        public void Apply(SubString name, IHRONVisitor visitor)
        {
            if (visitor == null)
            {
                return;
            }

            visitor.Object_Begin(name);
            for (var index = 0; index < m_pairs.Length; index++)
            {
                var pair = m_pairs[index];
                var innerName = pair.Name.ToSubString();
                pair.Value.Apply(innerName, visitor);
            }
            visitor.Object_End(name);
        }

        public void ToString(StringBuilder sb)
        {
            sb.Append("{Object");
            for (var index = 0; index < m_pairs.Length; index++)
            {
                var pair = m_pairs[index];
                sb.Append(", '");
                sb.Append(pair.Name);
                sb.Append("' : ");
                pair.Value.ToString(sb);
            }
            sb.Append('}');
        }

        public override string ToString()
        {
            var sb = new StringBuilder(128);
            ToString(sb);
            return sb.ToString();
        }
    }

    sealed partial class HRONValue : IHRONEntity
    {
        readonly string m_value;
        public static readonly IHRONEntity Empty = new HRONValue("");

        public HRONValue(string value)
        {
            m_value = value ?? "";
        }

        public HRONSerializer.Type Type
        {
            get { return HRONSerializer.Type.Value; }
        }

        public IEnumerable<IHRONEntity> this[string name]
        {
            get { return Array<IHRONEntity>.Empty; }
        }

        public string Value
        {
            get { return m_value; }
        }

        public void Apply(SubString name, IHRONVisitor visitor)
        {
            if (visitor == null)
            {
                return;
            }

            visitor.Value_Begin(name);
            foreach (var line in m_value.ReadLines())
            {
                visitor.Value_Line(line);
            }
            visitor.Value_End(name);
        }

        public void ToString(StringBuilder sb)
        {
            sb.Append('"');
            sb.Append(m_value);
            sb.Append('"');
        }

        public override string ToString()
        {
            var sb = new StringBuilder(128);
            ToString(sb);
            return sb.ToString();
        }
    }

    sealed partial class HRONDynamicBuilderVisitor : IHRONVisitor
    {
        public struct Item
        {
            public readonly SubString Name;
            public readonly List<HRONObject.Pair> Pairs;

            public Item(SubString name)
                : this()
            {
                Name = name;
                Pairs = new List<HRONObject.Pair>();
            }
        }

        readonly Stack<Item> m_stack = new Stack<Item>();
        readonly StringBuilder m_value = new StringBuilder(128);
        bool m_firstLine = true;

        public readonly List<HRONDynamicParseError> Errors = new List<HRONDynamicParseError>();
        public readonly int MaxErrors;

        public HRONDynamicBuilderVisitor(int maxErrors)
        {
            MaxErrors = maxErrors;
            m_stack.Push(new Item("Root".ToSubString()));
        }

        public Item Top
        {
            get { return m_stack.Peek(); }
        }

        public void Empty(SubString line)
        {
        }

        public void Comment(int indent, SubString comment)
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
            AddEntity(pop.Name.Value, new HRONObject(pop.Pairs.ToArray()));
        }

        void AddEntity(string name, IHRONEntity entity)
        {
            Top.Pairs.Add(new HRONObject.Pair(name, entity));
        }

        public void Error(int lineNo, SubString line, HRONSerializer.ParseError parseError)
        {
            Errors.Add(new HRONDynamicParseError(lineNo, line.Value, parseError));
        }
    }


    static partial class HRONSerializer
    {
        public enum Type
        {
            Value,
            Object,
        }

        public static void VisitDynamic (
            HRONObject hronObject,
            IHRONVisitor visitor
            )
        {
            if (hronObject == null)
            {
                return;
            }

            hronObject.Visit(visitor);
        }

        public static string DynamicAsString (
            HRONObject hronObject
            )
        {
            if (hronObject == null)
            {
                return "";
            }

            var v = new HRONWriterVisitor();
            VisitDynamic(hronObject, v);
            return v.Value;
        }

        public static bool TryParseDynamic(
            int maxErrorCount,
            IEnumerable<SubString> lines,
            out HRONObject hronObject,
            out HRONDynamicParseError[] errors
            )
        {
            hronObject = null;
            errors = Array<HRONDynamicParseError>.Empty;

            var visitor = new HRONDynamicBuilderVisitor(maxErrorCount);

            Parse(maxErrorCount, lines, visitor);

            if (visitor.Errors.Count > 0)
            {
                errors = visitor.Errors.ToArray();
                return false;
            }

            hronObject = new HRONObject(visitor.Top.Pairs.ToArray());

            return true;
        }

    }
}
