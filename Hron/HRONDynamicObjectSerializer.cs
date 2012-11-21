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
// ### INCLUDE: ../Extensions/ParseExtensions.cs


using System;

namespace Source.HRON
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Text;

    using Source.Common;
    using Source.Extensions;

    static partial class HronExtensions
    {
        public static IHRONEntity FirstOrEmpty (this IEnumerable<IHRONEntity> entities)
        {
            if (entities == null)
            {
                return HRONValue.Empty;
            }

            return entities.FirstOrDefault() ?? HRONValue.Empty;
        }
    }

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
        HRONSerializer.DynamicType GetDynamicType();

        IEnumerable<string>      GetMemberNames();
        IEnumerable<IHRONEntity> GetMember(string name);
        string GetValue();

        void Apply(SubString name, IHRONVisitor visitor);
        void ToString(StringBuilder sb);
    }

    sealed partial class HRONDynamicMembers : DynamicObject
    {
        readonly IHRONEntity[] m_entities;

        public HRONDynamicMembers(IEnumerable<IHRONEntity> entities)
        {
            m_entities = (entities ?? Array<IHRONEntity>.Empty).ToArray ();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var first = true;

            foreach (var entity in m_entities)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                entity.ToString(sb);
            }

            return sb.ToString();
        }

        public int GetCount ()
        {
            return m_entities.Length;
        }

        public bool Exists ()
        {
            return m_entities.Length > 0;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1 && indexes[0] is int)
            {
                var index = (int)indexes[0];
                if (index < 0)
                {
                    result = HRONValue.Empty;
                    return true;
                }

                if (index >= m_entities.Length)
                {
                    result = HRONValue.Empty;
                    return true;
                }

                result = m_entities[index];
                return true;
            }

            return base.TryGetIndex(binder, indexes, out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var entity = m_entities.FirstOrEmpty();

            var dynamicObject = entity as DynamicObject;
            if (dynamicObject != null)
            {
                return dynamicObject.TryGetMember(binder, out result);
            }

            return base.TryGetMember(binder, out result);
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            var returnType = binder.ReturnType;
            if (returnType == typeof(string))
            {
                result = m_entities.FirstOrEmpty().GetValue ();
                return true;
            }
            else if (returnType == typeof(string[]))
            {
                result = m_entities.Select(e => e.GetValue()).ToArray();
                return true;
            }
            else if (returnType ==typeof(object[]))
            {
                result = m_entities;
                return true;
            }
            else if (returnType.CanParse())
            {
                result = m_entities.FirstOrEmpty().GetValue().Parse(Config.DefaultCulture, returnType, returnType.GetDefaultValue());
                return true;                
            }
            else if (returnType.IsArray)
            {
                var elementType = returnType.GetElementType();
                if (elementType.CanParse())
                {
                    var values = m_entities.Select(entity => entity.GetValue().Parse(Config.DefaultCulture, elementType, elementType.GetDefaultValue())).ToArray();
                    var array = Array.CreateInstance(elementType, values.Length);
                    values.CopyTo(array, 0);
                    result = array;
                    return true;
                }
            }
            return base.TryConvert(binder, out result);
        }
    }

    abstract partial class BaseHRONEntity : DynamicObject, IHRONEntity
    {
        public abstract HRONSerializer.DynamicType GetDynamicType();
        public abstract IEnumerable<string> GetMemberNames();
        public abstract IEnumerable<IHRONEntity> GetMember(string name);
        public abstract string GetValue();

        public abstract void Apply(SubString name, IHRONVisitor visitor);
        public abstract void ToString(StringBuilder sb);

        public override string ToString()
        {
            var sb = new StringBuilder(128);
            ToString(sb);
            return sb.ToString();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = new HRONDynamicMembers(GetMember(binder.Name));
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            var returnType = binder.ReturnType;
            if (returnType == typeof(string))
            {
                result = GetValue();
                return true;
            }
            else if (returnType.CanParse())
            {
                result = GetValue().Parse(Config.DefaultCulture, returnType, returnType.GetDefaultValue ());
                return true;
            }
            return base.TryConvert(binder, out result);
        }

    }

    sealed partial class HRONObject : BaseHRONEntity
    {
        public partial struct Member
        {
            readonly string m_name;
            readonly IHRONEntity m_value;

            public Member(string name, IHRONEntity value)
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
        readonly Member[] m_members;

        public HRONObject(Member[] members)
        {
            m_members = members ?? Array<Member>.Empty;
        }

        ILookup<string, IHRONEntity> GetLookup()
        {
            if (m_lookup == null)
            {
                m_lookup = m_members.ToLookup(p => p.Name, p => p.Value);
            }

            return m_lookup;
        }

        public override HRONSerializer.DynamicType GetDynamicType()
        {
            return HRONSerializer.DynamicType.Object;
        }

        public override IEnumerable<string> GetMemberNames()
        {
            for (int index = 0; index < m_members.Length; index++)
            {
                var pair = m_members[index];
                yield return pair.Name;
            }
        }

        public override IEnumerable<IHRONEntity> GetMember(string name)
        {
            return GetLookup()[name ?? ""]; 
        }

        public override string GetValue()
        {
            return "";
        }

        public void Visit (IHRONVisitor visitor)
        {
            if (visitor == null)
            {
                return;
            }

            for (var index = 0; index < m_members.Length; index++)
            {
                var pair = m_members[index];
                var innerName = pair.Name.ToSubString();
                pair.Value.Apply(innerName, visitor);
            }
        }

        public override void Apply(SubString name, IHRONVisitor visitor)
        {
            if (visitor == null)
            {
                return;
            }

            visitor.Object_Begin(name);
            for (var index = 0; index < m_members.Length; index++)
            {
                var pair = m_members[index];
                var innerName = pair.Name.ToSubString();
                pair.Value.Apply(innerName, visitor);
            }
            visitor.Object_End(name);
        }

        public override void ToString(StringBuilder sb)
        {
            sb.Append("{Object");
            for (var index = 0; index < m_members.Length; index++)
            {
                var pair = m_members[index];
                sb.Append(", '");
                sb.Append(pair.Name);
                sb.Append("' : ");
                pair.Value.ToString(sb);
            }
            sb.Append('}');
        }
    }

    sealed partial class HRONValue : BaseHRONEntity
    {
        readonly string m_value;
        public static readonly IHRONEntity Empty = new HRONValue("");

        public HRONValue(string value)
        {
            m_value = value ?? "";
        }

        public override HRONSerializer.DynamicType GetDynamicType()
        {
            return HRONSerializer.DynamicType.Value;
        }

        public override IEnumerable<string> GetMemberNames()
        {
            return Array<string>.Empty;
        }

        public override IEnumerable<IHRONEntity> GetMember(string name)
        {
            return Array<IHRONEntity>.Empty;
        }

        public override string GetValue()
        {
            return m_value;
        }

        public override void Apply(SubString name, IHRONVisitor visitor)
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

        public override void ToString(StringBuilder sb)
        {
            sb.Append('"');

            var first = true;

            foreach (var line in m_value.ReadLines())
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }
                sb.AppendSubString(line);                
            }
            sb.Append('"');
        }
    }

    sealed partial class HRONDynamicBuilderVisitor : IHRONVisitor
    {
        public struct Item
        {
            public readonly SubString Name;
            public readonly List<HRONObject.Member> Pairs;

            public Item(SubString name)
                : this()
            {
                Name = name;
                Pairs = new List<HRONObject.Member>();
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

        public void Document_Begin()
        {
        }

        public void Document_End()
        {
        }

        public void PreProcessor(SubString line)
        {
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
            Top.Pairs.Add(new HRONObject.Member(name, entity));
        }

        public void Error(int lineNo, SubString line, HRONSerializer.ParseError parseError)
        {
            Errors.Add(new HRONDynamicParseError(lineNo, line.Value, parseError));
        }
    }


    static partial class HRONSerializer
    {
        public enum DynamicType
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
            out dynamic dyn,
            out HRONDynamicParseError[] errors
            )
        {
            HRONObject hronObject;

            if (!TryParseDynamic(maxErrorCount, lines, out hronObject, out errors))
            {
                dyn = null;
                return false;
            }

            dyn = hronObject;
            return true;
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
