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
// ### INCLUDE: ../Reflection/ClassDescriptor.cs
// ### INCLUDE: ../Reflection/StaticReflection.cs

namespace Source.HRON
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Source.Common;
    using Source.Extensions;
    using Source.Reflection;

    partial class HRONObjectParseError
    {
        public readonly int LineNo;
        public readonly string Line;
        public readonly HRONSerializer.ParseError ParseError;

        public HRONObjectParseError(int lineNo, string line, HRONSerializer.ParseError parseError)
        {
            LineNo = lineNo;
            Line = line;
            ParseError = parseError;
        }
    }

    sealed partial class HRONObjectBuilderVisitor<T> : IHRONVisitor
    {
        partial struct Item
        {
            public readonly ClassDescriptor ClassDescriptor;
            public readonly object Value;
            public readonly HashSet<MemberDescriptor> MembersAssignedTo;

            public Item(Type type)
                : this()
            {
                if (type == null)
                {
                    return;
                }

                ClassDescriptor = type.GetClassDescriptor();
                Value = ClassDescriptor.Creator();
                MembersAssignedTo = new HashSet<MemberDescriptor>();
            }
        }

        readonly Stack<Item> m_stack = new Stack<Item>();
        public readonly List<HRONObjectParseError> Errors = new List<HRONObjectParseError>();
        public readonly int MaxErrors;
        readonly StringBuilder m_value = new StringBuilder(128);
        bool m_firstLine = true;

        public HRONObjectBuilderVisitor(int maxErrorCount)
        {
            MaxErrors = maxErrorCount;
            m_stack.Push(new Item(typeof(T)));
        }

        Item Top
        {
            get { return m_stack.Peek(); }
        }

        public T Instance
        {
            get { return (T)Top.Value; }
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
            if (Top.Value == null)
            {
                return;
            }
            m_firstLine = true;
            m_value.Clear();
        }

        public void Value_Line(SubString value)
        {
            if (Top.Value == null)
            {
                return;
            }
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

        static bool IsAssignableFromString(Type type)
        {
            return
                    type == typeof(string)
                || type == typeof(object)
                ;
        }

        public void Value_End(SubString name)
        {
            var top = Top;
            if (top.Value == null)
            {
                return;
            }

            var value = m_value.ToString();

            var classDescriptor = top.ClassDescriptor;
            var itemName = name.ToString();
            var memberDescriptor = classDescriptor.FindMember(itemName);

            if (memberDescriptor == null)
            {
                if (classDescriptor.IsDictionaryLike)
                {
                    if (!IsAssignableFromString(classDescriptor.DictionaryKeyType))
                    {
                        // TODO: Log?
                        return;
                    }

                    var dictionary = (IDictionary)top.Value;

                    if (dictionary.Contains(itemName))
                    {
                        // TODO: Log?
                        return;
                    }

                    var itemType = classDescriptor.DictionaryValueType;
                    if (IsAssignableFromString(itemType))
                    {
                        dictionary.Add(itemName, value);
                        return;
                    }

                    var parsedValue = value.Parse(
                        Config.DefaultCulture,
                        itemType,
                        null
                        );

                    if (parsedValue == null)
                    {
                        // TODO: Log?
                        return;
                    }

                    dictionary.Add(itemName, parsedValue);
                }
                else if (classDescriptor.IsListLike)
                {
                    var list = (IList)top.Value;

                    if (list.IsReadOnly)
                    {
                        // TODO: Log?
                        return;
                    }

                    if (IsAssignableFromString(classDescriptor.ListItemType))
                    {
                        list.Add (value);
                    }

                    var itemType = classDescriptor.ListItemType;

                    var parsedValue = value.Parse(
                        Config.DefaultCulture,
                        itemType,
                        null
                        );
    
                    if (parsedValue == null)
                    {
                        // TODO: Log?
                        return;
                    }

                    list.Add (parsedValue);
                }
                else
                {
                    // TODO: Log?
                    return;
                }

                return;
            }

            var memberClassDescriptor = memberDescriptor.ClassDescriptor;

            if (memberClassDescriptor.IsListLike)
            {
                var list = (IList)memberDescriptor.Getter(top.Value);

                if (list == null)
                {
                    if (!memberDescriptor.HasSetter)
                    {
                        // TODO: Log?
                        return;
                    }

                    if (!memberClassDescriptor.HasCreator)
                    {
                        // TODO: Log?
                        return;
                    }

                    list = (IList)memberClassDescriptor.Creator();

                    if (list.IsReadOnly)
                    {
                        // TODO: Log?
                        return;
                    }

                    memberDescriptor.Setter(top.Value, list);
                    top.MembersAssignedTo.Add(memberDescriptor);
                }

                var itemType = memberClassDescriptor.ListItemType;

                if (IsAssignableFromString(itemType))
                {
                    list.Add(value);
                    return;
                }

                var parsedValue = value.Parse(
                    Config.DefaultCulture,
                    itemType,
                    null
                    );

                if (parsedValue == null)
                {
                    // TODO: Log?
                    return;
                }

                list.Add(parsedValue);
            }
            else
            {
                if (!memberDescriptor.HasSetter)
                {
                    // TODO: Log?
                    return;
                }

                if (top.MembersAssignedTo.Contains(memberDescriptor))
                {
                    // TODO: Log?
                    return;
                }

                if (IsAssignableFromString(memberDescriptor.MemberType))
                {
                    memberDescriptor.Setter(top.Value, value);
                    top.MembersAssignedTo.Add(memberDescriptor);
                    return;
                }

                var parsedValue = value.Parse(
                    Config.DefaultCulture,
                    memberDescriptor.MemberType,
                    null
                    );

                if (parsedValue == null)
                {
                    // TODO: Log?
                    return;
                }

                memberDescriptor.Setter(top.Value, parsedValue);
                top.MembersAssignedTo.Add(memberDescriptor);
            }
        }

        public void Object_Begin(SubString name)
        {
            var top = Top;
            if (top.Value == null)
            {
                return;
            }

            Type type = null;
            try
            {
                var classDescriptor = top.ClassDescriptor;
                var itemName = name.ToString();
                var memberDescriptor = classDescriptor.FindMember(itemName);

                if (memberDescriptor == null)
                {
                    if (classDescriptor.IsDictionaryLike)
                    {
                        if (!IsAssignableFromString(classDescriptor.DictionaryKeyType))
                        {
                            // TODO: Log?
                            return;
                        }

                        var dictionary = (IDictionary)top.Value;

                        if (dictionary.Contains(itemName))
                        {
                            // TODO: Log?
                            return;
                        }

                        var itemType = classDescriptor.DictionaryValueType;

                        if (IsAssignableFromString(itemType))
                        {
                            // TODO: Log?
                            return;
                        }

                        type = itemType.GetClassDescriptor().NonNullableType;
                    }
                    else if (classDescriptor.IsListLike)
                    {
                        var itemType = classDescriptor.ListItemType;

                        if (IsAssignableFromString(itemType))
                        {
                            // TODO: Log?
                            return;
                        }

                        type = itemType.GetClassDescriptor().NonNullableType;
                    }
                    else
                    {
                        // TODO: Log?
                        return;
                    }

                    return;
                }

                var memberClassDescriptor = memberDescriptor.ClassDescriptor;
                if (memberClassDescriptor.IsListLike)
                {
                    var list = (IList)memberDescriptor.Getter(top.Value);

                    if (list == null)
                    {
                        if (!memberDescriptor.HasSetter)
                        {
                            // TODO: Log?
                            return;
                        }

                        if (!memberClassDescriptor.HasCreator)
                        {
                            // TODO: Log?
                            return;
                        }
                    }

                    var itemType = memberClassDescriptor.ListItemType;

                    if (IsAssignableFromString(itemType))
                    {
                        // TODO: Log?
                        return;
                    }

                    type = itemType.GetClassDescriptor().NonNullableType;
                }
                else
                {
                    if (!memberDescriptor.HasSetter)
                    {
                        // TODO: Log?
                        return;
                    }

                    if (top.MembersAssignedTo.Contains(memberDescriptor))
                    {
                        // TODO: Log?
                        return;
                    }

                    if (IsAssignableFromString(memberDescriptor.MemberType))
                    {
                        // TODO: Log?
                        return;
                    }

                    type = memberDescriptor.ClassDescriptor.NonNullableType;
                }
            }
            finally
            {
                m_stack.Push(new Item(type));
            }
        }

        public void Object_End(SubString name)
        {
            var value = Top;
            m_stack.Pop();
            var top = Top;

            if (value.Value == null)
            {
                return;
            }

            if (top.Value == null)
            {
                return;
            }

            var classDescriptor = top.ClassDescriptor;
            var itemName = name.ToString();
            var memberDescriptor = classDescriptor.FindMember(itemName);

            if (memberDescriptor == null)
            {
                if (classDescriptor.IsDictionaryLike)
                {
                    var dictionary = (IDictionary)top.Value;

                    if (dictionary.Contains(itemName))
                    {
                        // TODO: Log?
                        return;
                    }

                    dictionary.Add(itemName, value);
                }
                else if (classDescriptor.IsListLike)
                {
                    var list = (IList)top.Value;

                    if (list.IsReadOnly)
                    {
                        // TODO: Log?
                        return;
                    }

                    list.Add(value);
                }
                else
                {
                    // TODO: Log?
                    return;
                }

                return;
            }
            var memberClassDescriptor = memberDescriptor.ClassDescriptor;

            if (memberClassDescriptor.IsListLike)
            {
                var list = (IList)memberDescriptor.Getter(top.Value);

                if (list == null)
                {
                    list = (IList)memberClassDescriptor.Creator();

                    if (list.IsReadOnly)
                    {
                        // TODO: Log?
                        return;
                    }

                    memberDescriptor.Setter(top.Value, list);
                    top.MembersAssignedTo.Add(memberDescriptor);
                }

                list.Add(value.Value);
            }
            else
            {
                top.MembersAssignedTo.Add(memberDescriptor);
                memberDescriptor.Setter(top.Value, value.Value);
            }
        }

        public void Error(int lineNo, SubString line, HRONSerializer.ParseError parseError)
        {
            Errors.Add(new HRONObjectParseError(lineNo, line.Value, parseError));
        }
    }

    static partial class HRONSerializer
    {
        public static bool TryParseObject<T>(
            int maxErrorCount,
            IEnumerable<SubString> lines,
            out T hronObject,
            out HRONObjectParseError[] errors
            )
        {
            hronObject = default(T);
            errors = Array<HRONObjectParseError>.Empty;

            var visitor = new HRONObjectBuilderVisitor<T>(maxErrorCount);

            Parse(maxErrorCount, lines, visitor);

            if (visitor.Errors.Count > 0)
            {
                errors = visitor.Errors.ToArray();
                return false;
            }

            hronObject = visitor.Instance;

            return true;
        }

        public static string ObjectAsString<T>(T value, bool omitIfNullOrEmpty = true)
        {
            var visitor = new HRONWriterVisitor();
            VisitObject(value, visitor, omitIfNullOrEmpty);
            return visitor.Value;
        }
    
        public static void VisitObject(
            object value,
            IHRONVisitor visitor,
            bool omitIfNullOrEmpty = true
            )
        {
            if (value == null)
            {
                return;
            }
    
            var type = value.GetType();
            var classDescriptor = type.GetClassDescriptor();
    
            if (classDescriptor.IsDictionaryLike)
            {
                var dictionary = (IDictionary)value;
                foreach (var key in dictionary.Keys)
                {
                    var innerValue = dictionary[key];
                    var keyAsString = key as string;
                    if (keyAsString != null)
                    {
                        VisitMember(keyAsString.ToSubString(), innerValue, visitor, omitIfNullOrEmpty);
                    }
                }
            }
            else if (classDescriptor.IsListLike)
            {
                var list = (IList)value;
                for (var index = 0; index < list.Count; index++)
                {
                    var innerValue = list[index];
                    VisitMember(new SubString(), innerValue, visitor, omitIfNullOrEmpty);
                }
            }
            else
            {
                for (var index = 0; index < classDescriptor.PublicGetMembers.Length; index++)
                {
                    var mi = classDescriptor.PublicGetMembers[index];
                    var memberName = mi.Name.ToSubString();
                    var memberValue = mi.Getter(value);
                    VisitMember(memberName, memberValue, visitor, omitIfNullOrEmpty);
                }
            }
        }

        static void VisitMember(SubString memberName, object memberValue, IHRONVisitor visitor, bool omitIfNullOrEmpty)
        {
            if (memberValue == null)
            {
                if (!omitIfNullOrEmpty)
                {
                    visitor.Value_Begin(memberName);
                    visitor.Value_End(memberName);
                }
                return;
            }
    
            var classDescriptor = memberValue.GetType().GetClassDescriptor();
    
            if (classDescriptor.IsDictionaryLike)
            {
                visitor.Object_Begin(memberName);
                var dictionary = (IDictionary)memberValue;
                foreach (var key in dictionary.Keys)
                {
                    var innerValue = dictionary[key];
                    var keyAsString = key as string;
                    if (keyAsString != null)
                    {
                        VisitMember(keyAsString.ToSubString(), innerValue, visitor, omitIfNullOrEmpty);
                    }
                }
                visitor.Object_End(memberName);
            }
            else if (classDescriptor.IsListLike)
            {
                var list = (IList)memberValue;
                for (var index = 0; index < list.Count; index++)
                {
                    var innerValue = list[index];
                    VisitMember(memberName, innerValue, visitor, omitIfNullOrEmpty);
                }
            }
            else if (memberValue is string)
            {
                var innerValue = (string)memberValue;
                if (!innerValue.IsNullOrEmpty())
                {
                    visitor.Value_Begin(memberName);
                    foreach (var line in innerValue.ReadLines())
                    {
                        visitor.Value_Line(line);
                    }
                    visitor.Value_End(memberName);
                }
                else if (!omitIfNullOrEmpty)
                {
                    visitor.Value_Begin(memberName);
                    visitor.Value_End(memberName);
                }
            }
            else if (classDescriptor.Type.CanParse())
            {
                var memberAsString = memberValue.ToString();
                // These types are never multilined, but may be empty
                if (!memberAsString.IsNullOrEmpty())
                {
                    visitor.Value_Begin(memberName);
                    visitor.Value_Line(memberAsString.ToSubString());
                    visitor.Value_End(memberName);
                }
                else if (!omitIfNullOrEmpty)
                {
                    visitor.Value_Begin(memberName);
                    visitor.Value_End(memberName);
                }
            }
            else
            {
                visitor.Object_Begin(memberName);
                VisitObject(memberValue, visitor);
                visitor.Object_End(memberName);
            }
        }

    }
}
