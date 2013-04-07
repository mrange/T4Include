
// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # text template file (.tt)                                                 #
// ############################################################################



// ############################################################################
// @@@ INCLUDING: C:\temp\GitHub\T4Include\HRON\HRONObjectSerializer.cs
// @@@ INCLUDE_FOUND: HRONSerializer.cs
// @@@ INCLUDE_FOUND: ../Extensions/ParseExtensions.cs
// @@@ INCLUDE_FOUND: ../Reflection/ClassDescriptor.cs
// @@@ INCLUDE_FOUND: ../Reflection/StaticReflection.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\HRON\HRONDynamicObjectSerializer.cs
// @@@ INCLUDE_FOUND: HRONSerializer.cs
// @@@ INCLUDE_FOUND: ../Extensions/EnumParseExtensions.cs
// @@@ INCLUDE_FOUND: ../Extensions/ParseExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\ConsoleLog.cs
// @@@ INCLUDE_FOUND: Config.cs
// @@@ INCLUDE_FOUND: Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Concurrency\TaskSchedulers.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDE_FOUND: ShutDownable.cs
// @@@ INCLUDE_FOUND: RemainingTime.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDE_FOUND: ../Common/Config.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\SqlExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Testing\TestRunner.cs
// @@@ INCLUDE_FOUND: ../Common/Config.cs
// @@@ INCLUDE_FOUND: ../Common/Log.cs
// @@@ INCLUDE_FOUND: ../Extensions/BasicExtensions.cs
// @@@ INCLUDE_FOUND: TestFor.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Text\LineToObjectExtensions.cs
// @@@ INCLUDE_FOUND: LineReaderExtensions.cs
// @@@ INCLUDE_FOUND: ../Extensions/BasicExtensions.cs
// @@@ INCLUDE_FOUND: ../Reflection/ClassDescriptor.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\SQL\Schema.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\HRON\HRONSerializer.cs
// @@@ INCLUDE_FOUND: ../Common/Array.cs
// @@@ INCLUDE_FOUND: ../Common/Config.cs
// @@@ INCLUDE_FOUND: ../Common/SubString.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\ParseExtensions.cs
// @@@ INCLUDE_FOUND: ../Common/Config.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Reflection\ClassDescriptor.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Reflection\StaticReflection.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\HRON\HRONSerializer.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Extensions\EnumParseExtensions.cs
// @@@ INCLUDE_FOUND: ../Reflection/StaticReflection.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Extensions\ParseExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ INCLUDE_FOUND: Config.cs
// @@@ INCLUDE_FOUND: Generated_Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Concurrency\ShutDownable.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Concurrency\RemainingTime.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Log.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Testing\TestFor.cs
// @@@ INCLUDE_FOUND: Generated_TestFor.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Text\LineReaderExtensions.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Reflection\ClassDescriptor.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Array.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\SubString.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Reflection\StaticReflection.cs
// @@@ SKIPPING (Already seen): C:\temp\GitHub\T4Include\Common\Config.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\Testing\Generated_TestFor.cs
// ############################################################################
// Certains directives such as #define and // Resharper comments has to be 
// moved to top in order to work properly    
// ############################################################################
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCaseLabel
// ReSharper disable RedundantIfElseBlock
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantTypeArgumentsOfMethod
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\HRON\HRONObjectSerializer.cs
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
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\HRON\HRONObjectSerializer.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\HRON\HRONDynamicObjectSerializer.cs
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
        using System;
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
    
            public override IEnumerable<string> GetDynamicMemberNames ()
            {
                var entity = m_entities.FirstOrEmpty ();
                return entity.GetMemberNames ();
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
    
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                var entity = m_entities.FirstOrEmpty();
    
                var dynamicObject = entity as DynamicObject;
                if (dynamicObject != null)
                {
                    return dynamicObject.TryInvokeMember(binder, args, out result);
                }
    
                return base.TryInvokeMember(binder, args, out result);
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
                else if (BaseHRONEntity.IsParseable (returnType))
                {
                    result = BaseHRONEntity.Parse (returnType, m_entities.FirstOrEmpty().GetValue());
                    return true;                
                }
                else if (returnType.IsArray)
                {
                    var elementType = returnType.GetElementType();
                    if (BaseHRONEntity.IsParseable (elementType))
                    {
                        var values = m_entities.Select (entity => BaseHRONEntity.Parse (elementType, entity.GetValue())).ToArray();
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
    
            internal static bool IsParseable (Type type)
            {
                return type.CanParseEnumValue() || type.CanParse();
            }
    
            public override IEnumerable<string> GetDynamicMemberNames ()
            {
                return GetMemberNames ();
            }
    
            internal static object Parse(Type type, string value)
            {
                value = value ?? "";
    
                if (type.CanParseEnumValue())                    
                {
                    return value.ParseEnumValue(type) ?? type.GetDefaultEnumValue ();
                }
    
                return value.Parse (Config.DefaultCulture, type, type.GetParsedDefaultValue());
            }
    
    
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
    
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
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
                else if (IsParseable(returnType))
                {
                    result = Parse(returnType, GetValue());
                    return true;
                }
                return base.TryConvert(binder, out result);
            }
    
        }
    
        sealed partial class HRONObject : BaseHRONEntity
        {
            public static HRONObject Empty = new HRONObject (null);
    
            public partial struct Member
            {
                readonly string m_name;
                readonly IHRONEntity m_value;
    
                public Member(string name, IHRONEntity value)
                    : this()
                {
                    m_name = name.Trim ();
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
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\HRON\HRONDynamicObjectSerializer.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\ConsoleLog.cs
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
        using System;
        using System.Globalization;
    
        partial class Log
        {
            static readonly object s_colorLock = new object ();
            static partial void Partial_LogMessage (Level level, string message)
            {
                var now = DateTime.Now;
                var finalMessage = string.Format (
                    Config.DefaultCulture,
                    "{0:HHmmss} {1} : {2}",
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
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\ConsoleLog.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Concurrency\TaskSchedulers.cs
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
    
    
    
    namespace Source.Concurrency
    {
        using System;
        using System.Collections.Concurrent;
        using System.Collections.Generic;
        using System.Threading;
        using System.Threading.Tasks;
    
        using Source.Common;
    
        sealed partial class SequentialTaskScheduler : TaskScheduler, IShutDownable
        {
            const int                           DefaultTimeOutInMs = 250;
            public readonly string              Name    ;
            public readonly TimeSpan            TimeOut ;
    
            readonly BlockingCollection<Task>   m_tasks = new BlockingCollection<Task>();
            Thread                              m_executingThread   ;
            bool                                m_done              ;
    
            int                                 m_taskFailureCount;
    
    
            partial void Partial_ThreadCreated (Thread thread);
    
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
    
                Partial_ThreadCreated (m_executingThread);
    
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
    
            public void SignalShutDown ()
            {
                if (!m_done)
                {
                    m_done = true;
                    // null task to wake up thread
                    m_tasks.Add (null);                
                }
            }
    
            public void ShutDown (RemainingTime remainingTime)
            {
                var thread = Interlocked.Exchange (ref m_executingThread, null);
                if (thread != null)
                {
                    try
                    {
                        SignalShutDown ();
                        var joinTimeOut = (int)remainingTime.Remaining.TotalMilliseconds/2;
                        if (!thread.Join (joinTimeOut))
                        {
                            Log.Warning (
                                "SequentialTaskScheduler.Dispose: {0} - Executing thread didn't shutdown, aborting it...",
                                Name
                                );        
    
                            thread.Abort ();
                            var abortTimeOut = remainingTime.Remaining;
                            if (!thread.Join (abortTimeOut))
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
    
            public void Dispose ()
            {
                ShutDown (new RemainingTime (TimeOut));
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Concurrency\TaskSchedulers.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs
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
    
            public static T FirstOrReturn<T>(this T[] values, T defaultValue)
            {
                if (values == null)
                {
                    return defaultValue;
                }
    
                if (values.Length == 0)
                {
                    return defaultValue;
                }
    
                return values[0];
            }
    
            public static T FirstOrReturn<T>(this IEnumerable<T> values, T defaultValue)
            {
                if (values == null)
                {
                    return defaultValue;
                }
    
                foreach (var value in values)
                {
                    return value;
                }
    
                return defaultValue;
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
                return format.FormatWith (Config.DefaultCulture, args);
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
    
                return string.Join (delimiter, values);
            }
    
            public static string GetResourceString (this Assembly assembly, string name, string defaultValue = null)
            {
                defaultValue = defaultValue ?? "";
    
                if (assembly == null)
                {
                    return defaultValue;
                }
    
                var stream = assembly.GetManifestResourceStream (name ?? "");
                if (stream == null)
                {
                    return defaultValue;
                }
    
                using (stream)
                using (var streamReader = new StreamReader (stream))
                {
                    return streamReader.ReadToEnd ();
                }
            }
    
            public static IEnumerable<string> ReadLines (this TextReader textReader)
            {
                if (textReader == null)
                {
                    yield break;
                }
    
                string line;
    
                while ((line = textReader.ReadLine ()) != null)
                {
                    yield return line;
                }
            }
    
    #if !NETFX_CORE
            public static IEnumerable<Type> GetInheritanceChain (this Type type)
            {
                while (type != null)
                {
                    yield return type;
                    type = type.BaseType;
                }
            }
    #endif
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Extensions\SqlExtensions.cs
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
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Data;
    
        static partial class SqlExtensions
        {
            public static TValue Get<TValue>(this IDataReader reader, int index, TValue defaultValue)
            {
                if (reader == null)
                {
                    return defaultValue;
                }
                
                if (index < 0)
                {
                    return defaultValue;
                }
    
                if (index >= reader.FieldCount)
                {
                    return defaultValue;
                }
    
                var value = reader.GetValue (index);
    
                if (value is DBNull)
                {
                    return defaultValue;
                }
    
                if (!(value is TValue))
                {
                    return defaultValue;
                }
    
                return (TValue) value;
            }
    
            public static TValue Get<TValue>(this IDataReader reader, string name, TValue defaultValue)
            {
                if (reader == null)
                {
                    return defaultValue;
                }
                
                var index = reader.GetOrdinal(name ?? "");
    
                return reader.Get(index, defaultValue);
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Extensions\SqlExtensions.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Testing\TestRunner.cs
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
    
    
    namespace Source.Testing
    {
        using System;
        using System.Linq;
        using System.Reflection;
        using Source.Common;
    
        static partial class TestRunner
        {
            public static bool ExecuteTests (Assembly assemblyContainingTests = null)
            {
                var assembly = assemblyContainingTests ?? Assembly.GetExecutingAssembly();
    
                var preFailureCount = TestFor.FailureCount;
                var assemblyName = assembly.GetName().Name;
                try
                {
                    Log.Info("Executing tests contained in: {0}", assemblyName);
    
                    Log.Info("Locating test classes...");
                    var testClasses = assembly
                        .GetTypes()
                        .Where(t => t.Name.StartsWith("TestsFor_", StringComparison.OrdinalIgnoreCase))
                        .OrderBy(t => t.Name)
                        .ToArray()
                        ;
                    Log.HighLight("Found {0} test classes", testClasses.Length);
    
                    foreach (var testClass in testClasses)
                    {
                        var preClassFailureCount = TestFor.FailureCount;
                        var className = testClass.Name;
                        try
                        {
                            Log.Info("Executing tests contained in class: {0}", className);
                            var instance = Activator.CreateInstance(testClass, nonPublic: true);
                            using (var disposable = instance as IDisposable)
                            {
                                var testMethods = testClass
                                    .GetMethods()
                                    .Where(mi => mi.Name.StartsWith("Test_", StringComparison.OrdinalIgnoreCase))
                                    .ToArray();
    
                                foreach (var testMethod in testMethods)
                                {
                                    var preMethodFailureCount = TestFor.FailureCount;
                                    try
                                    {
                                        if (testMethod.GetParameters().Length > 0)
                                        {
                                            Log.Warning(
                                                "Can't execute test method as it has more than 0 parameters: {0}.{1}",
                                                className,
                                                testMethod.Name
                                                );
    
                                            continue;
                                        }
    
                                        Log.Info("Executing test: {0}.{1}", className, testMethod.Name);
    
                                        testMethod.Invoke(instance, new object[0]);
                                    }
                                    catch (Exception exc)
                                    {
                                        Log.Exception("Caught method level exception for: {0}", exc);
                                        ++TestFor.FailureCount;
                                    }
                                    finally
                                    {
                                        if (TestFor.FailureCount == preMethodFailureCount)
                                        {
                                            Log.Success("Executed test: {0}.{1}", className, testMethod.Name);
                                        }
                                        else
                                        {
                                            Log.Error("Executed test: {0}.{1}", className, testMethod.Name);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            Log.Exception("Caught class level exception", exc);
                            ++TestFor.FailureCount;
                        }
                        finally
                        {
                            if (preClassFailureCount == TestFor.FailureCount)
                            {
                                Log.Success("Executed tests in class: {0}", className);
                            }
                            else
                            {
                                Log.Error("Executed tests in class: {0}", className);
                            }
                        }
                    }
                }
                finally
                {
                    if (preFailureCount == TestFor.FailureCount)
                    {
                        Log.Success("Executed tests in assembly: {0}", assemblyName);
                    }
                    else
                    {
                        Log.Error("Executed tests in assembly: {0}", assemblyName);
                    }
                }
    
                return preFailureCount == TestFor.FailureCount;
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Testing\TestRunner.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Text\LineToObjectExtensions.cs
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
    
    
    
    namespace Source.Text
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using Source.Extensions;
        using Source.Reflection;
    
        static partial class LineToObjectExtensions
        {
            static partial void ParserWarning(string format, params object[] args);
    
            public static IEnumerable<T> TextToObjects<T>(this IEnumerable<char> text, char separator = '\t') 
                where T : class, new()
            {
                return text.TextToLines(separator).LineToObject<T>();
            }
    
            public static IEnumerable<T> LineToObject<T>(this IEnumerable<Line> lines)
                where T : class, new()
            {
                if (lines == null)
                {
                    yield break;
                }
    
                var classDescriptor = ClassDescriptor.GetClassDescriptor(typeof(T));
    
                using (var e = lines.GetEnumerator())
                {
                    Line header = null;
                    string[] allFields = null;
                    HashSet<string> allValidFields = null;
                    if (e.MoveNext())
                    {
                        header = e.Current;
    
                        allFields = header.Fields.Select(f => f.Trim()).ToArray();
    
                        var allMembers = classDescriptor
                            .Members
                            .Where(m => m.MemberInfo.GetCustomAttributes(typeof(IgnoreMemberAttribute), true).Length == 0)
                            .ToArray()
                            ;
    
                        var allWriteableMembers = allMembers
                            .Where(m => m.HasSetter)
                            .Select(memberDefinition => memberDefinition.Name)
                            .ToArray();
                        var allStringMembers = allMembers
                            .Where(m => m.MemberType == typeof(string))
                            .Select(memberDefinition => memberDefinition.Name)
                            .ToArray();
    
                        var allNonWriteableMembers = allMembers
                            .Where(m => !m.HasSetter)
                            .Select(memberDefinition => memberDefinition.Name)
                            .ToArray();
                        var allNonStringMembers = allMembers
                            .Where(m => m.MemberType != typeof(string))
                            .Select(memberDefinition => memberDefinition.Name)
                            .ToArray();
    
                        var emptyFieldCount = allFields.Count(s => s.IsNullOrWhiteSpace());
                        if (emptyFieldCount > 0)
                        {
                            ParserWarning("Empty field names in header line: {0}", emptyFieldCount);
                        }
    
                        var missingFields = allWriteableMembers.Except(allFields).ToArray();
                        if (missingFields.Length > 0)
                        {
                            ParserWarning("Missing field names in header line: {0}", missingFields.Concatenate());
                        }
    
                        var additionalFields = allFields.Except(allWriteableMembers).ToArray();
                        if (additionalFields.Length > 0)
                        {
                            ParserWarning("Additionals field names in header line (ignored): {0}", additionalFields.Concatenate());
                        }
    
                        var allNonWriteableFields = allFields.Intersect(allNonWriteableMembers).ToArray();
                        if (allNonWriteableFields.Length > 0)
                        {
                            ParserWarning("Non writeable fields referenced: {0}", allNonWriteableFields.Concatenate());
                        }
    
                        var allNonStringFields = allFields.Intersect(allNonStringMembers).ToArray();
                        if (allNonWriteableFields.Length > 0)
                        {
                            ParserWarning("Non string fields referenced: {0}", allNonStringFields.Concatenate());
                        }
    
                        allValidFields = new HashSet<string>(allFields
                                                                 .Intersect(allWriteableMembers)
                                                                 .Intersect(allStringMembers)
                            );
    
                    }
    
                    if (header == null)
                    {
                        yield break;
                    }
    
                    while (e.MoveNext())
                    {
                        var line = e.Current;
                        if (line.IsEmpty)
                        {
                            continue;
                        }
    
                        var lineFields = line.Fields;
    
                        if (allFields.Length < lineFields.Length)
                        {
                            ParserWarning(
                                "Line @{0} - {1} additinal fields detected",
                                line.LineNo,
                                lineFields.Length - allFields.Length
                                );
                        }
    
                        if (lineFields.Length < allFields.Length)
                        {
                            ParserWarning(
                                "Line @{0} - {1} missing fields detected",
                                line.LineNo,
                                allFields.Length - lineFields.Length
                                );
                        }
    
                        var instance = new T();
                        var lineSource = instance as IOriginatedFromLine;
                        if (lineSource != null)
                        {
                            lineSource.SetLine(line);
                        }
    
                        var max = Math.Min(lineFields.Length, allFields.Length);
    
                        for (var iter = 0; iter < max; ++iter)
                        {
                            var fieldName = allFields[iter];
                            var fieldValue = lineFields[iter] ?? "";
                            if (allValidFields.Contains(fieldName))
                            {
    
                                var memberDescriptor = classDescriptor.FindMember(fieldName);
                                if (memberDescriptor != null)
                                {
                                    memberDescriptor.Setter(instance, fieldValue.Trim());
                                }
                                else
                                {
                                    ParserWarning(
                                        "Line @{0} - Failed to set field {1}: {2}",
                                        line.LineNo,
                                        fieldName
                                        );
                                }
                            }
                        }
    
                        yield return instance;
                    }
                }
    
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Text\LineToObjectExtensions.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\SQL\Schema.cs
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
    
    
    
    
    namespace Source.SQL
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.SqlClient;
        using System.Globalization;
        using System.Linq;
        using System.Linq.Expressions;
        using System.Reflection;
        using System.Text;
        using System.Xml;
    
        sealed partial class TypeDefinition
        {
            internal sealed partial class SqlTypeInfo
            {
                public static readonly SqlTypeInfo Empty = new SqlTypeInfo (SqlDbType.Udt, typeof (object), -1, false, null);
    
                public readonly SqlDbType   DbType              ;
                public readonly Type        ClrType             ;
                public readonly int         DbTypeElementSize   ;
                public readonly bool        RequiresDimension   ;
                public readonly string      DbTypeName          ;
                public readonly string      CsTypeName          ;
    
                public readonly MethodInfo  GetterMethod        ;
    
    
                public SqlTypeInfo(SqlDbType dbType, Type type, int elementSize, bool requiresDimension, MethodInfo getterMethod)
                {
                    DbType              = dbType            ;
                    ClrType             = type              ;
                    DbTypeElementSize   = elementSize       ;
                    RequiresDimension   = requiresDimension ;
    
                    GetterMethod        = getterMethod      ;
    
                    DbTypeName          = dbType.ToString().ToLowerInvariant();
    
                    if (type.IsArray)
                    {
                        CsTypeName      = type.GetElementType().FullName + "[]";
                    }
                    else
                    {
                        CsTypeName      = type.FullName;
                    }
                }
            }
    
            static void Add<T> (byte id, SqlDbType dbType, int elementSize, bool requiresDimension, Expression<Func<SqlDataReader, T>> getter)
            {
                var getterMethodInfo = getter != null
                    ?   ((MethodCallExpression)getter.Body).Method   
                    :   null
                    ;
                s_typeInfoLookup.Add(id, new SqlTypeInfo(dbType, typeof(T), elementSize, requiresDimension, getterMethodInfo));
            }
    
            readonly static Dictionary<byte, SqlTypeInfo> s_typeInfoLookup = 
                new Dictionary<byte, SqlTypeInfo> ();
    
            static TypeDefinition ()
            {
                Add<Int64>           (127   , SqlDbType.BigInt           , getter:r => r.GetInt64(0)            , elementSize:8    , requiresDimension:false   );
                Add<Byte[]>          (173   , SqlDbType.Binary           , getter:null                          , elementSize:1    , requiresDimension:true    );
                Add<Boolean>         (104   , SqlDbType.Bit              , getter:r => r.GetBoolean(0)          , elementSize:1    , requiresDimension:false   );
                Add<String>          (175   , SqlDbType.Char             , getter:r => r.GetString(0)           , elementSize:1    , requiresDimension:true    );
                Add<DateTime>        (61    , SqlDbType.DateTime         , getter:r => r.GetDateTime(0)         , elementSize:8    , requiresDimension:false   );
                Add<Decimal>         (106   , SqlDbType.Decimal          , getter:r => r.GetDecimal(0)          , elementSize:17   , requiresDimension:false   );
                Add<Double>          (62    , SqlDbType.Float            , getter:r => r.GetDouble(0)           , elementSize:4    , requiresDimension:false   );
                Add<Byte[]>          (34    , SqlDbType.Image            , getter:null                          , elementSize:1    , requiresDimension:false   );  // TODO: Check this
                Add<Int32>           (56    , SqlDbType.Int              , getter:r => r.GetInt32(0)            , elementSize:4    , requiresDimension:false   );
                Add<Decimal>         (60    , SqlDbType.Money            , getter:r => r.GetDecimal(0)          , elementSize:8    , requiresDimension:false   );
                Add<String>          (239   , SqlDbType.NChar            , getter:r => r.GetString(0)           , elementSize:2    , requiresDimension:true    );
                Add<String>          (99    , SqlDbType.NText            , getter:r => r.GetString(0)           , elementSize:2    , requiresDimension:false   );
                Add<String>          (231   , SqlDbType.NVarChar         , getter:r => r.GetString(0)           , elementSize:2    , requiresDimension:true    );
                Add<Single>          (59    , SqlDbType.Real             , getter:r => r.GetFloat(0)            , elementSize:4    , requiresDimension:false   );
                Add<Guid>            (36    , SqlDbType.UniqueIdentifier , getter:r => r.GetGuid(0)             , elementSize:1    , requiresDimension:false   );
                Add<DateTime>        (58    , SqlDbType.SmallDateTime    , getter:r => r.GetDateTime(0)         , elementSize:4    , requiresDimension:false   );
                Add<Int16>           (52    , SqlDbType.SmallInt         , getter:r => r.GetInt16(0)            , elementSize:2    , requiresDimension:false   );
                Add<Decimal>         (122   , SqlDbType.SmallMoney       , getter:r => r.GetDecimal(0)          , elementSize:4    , requiresDimension:false   );
                Add<String>          (35    , SqlDbType.Text             , getter:r => r.GetString(0)           , elementSize:1    , requiresDimension:false   );
                Add<DateTime>        (189   , SqlDbType.Timestamp        , getter:r => r.GetDateTime(0)         , elementSize:8    , requiresDimension:false   );
                Add<Byte>            (48    , SqlDbType.TinyInt          , getter:r => r.GetByte(0)             , elementSize:1    , requiresDimension:false   );
                Add<Byte[]>          (165   , SqlDbType.VarBinary        , getter:null                          , elementSize:1    , requiresDimension:true    );
                Add<String>          (167   , SqlDbType.VarChar          , getter:r => r.GetString(0)           , elementSize:1    , requiresDimension:true    );
                Add<object>          (98    , SqlDbType.Variant          , getter:r => r.GetValue(0)            , elementSize: -1  , requiresDimension:false   );
                Add<XmlReader>       (241   , SqlDbType.Xml              , getter:r => r.GetXmlReader(0)        , elementSize:-1   , requiresDimension:false   );  
                Add<DateTime>        (40    , SqlDbType.Date             , getter:r => r.GetDateTime(0)         , elementSize:8    , requiresDimension:false   );
                Add<DateTime>        (41    , SqlDbType.Time             , getter:r => r.GetDateTime(0)         , elementSize:5    , requiresDimension:false   );
                Add<DateTime>        (42    , SqlDbType.DateTime2        , getter:r => r.GetDateTime(0)         , elementSize:8    , requiresDimension:false   );
                Add<DateTimeOffset>  (43    , SqlDbType.DateTimeOffset   , getter:r => r.GetDateTimeOffset(0)   , elementSize:10   , requiresDimension:false   );
            }                                                                                                                                 
    
     
            public static readonly TypeDefinition Empty = new TypeDefinition (
                "empty" ,
                "void"  ,
                0       ,
                0       ,
                0       ,
                0       ,
                0       ,
                ""      ,
                true
                );
    
    
            public readonly string      Schema      ;
            public readonly string      Name        ;
            public readonly string      FullName    ;
            public readonly byte        SystemTypeId;
            public readonly int         UserTypeId  ;
            public readonly short       MaxLength   ;
            public readonly byte        Precision   ;
            public readonly byte        Scale       ;
            public readonly string      Collation   ;
            public readonly bool        IsNullable  ;
    
            internal readonly SqlTypeInfo   TypeInfo    ;
            readonly string                 m_asString  ;
    
            public TypeDefinition(
                string  schema          , 
                string  name            , 
                byte    systemTypeId    , 
                int     userTypeId      , 
                short   maxLength       , 
                byte    precision       , 
                byte    scale           , 
                string  collation       , 
                bool    isNullable
                )
            {
                Schema          = schema            ?? "";
                Name            = name              ?? "";
                FullName        = Schema + "." + Name;
                SystemTypeId    = systemTypeId      ;
                UserTypeId      = userTypeId        ;
                MaxLength       = maxLength         ;
                Precision       = precision         ;
                Scale           = scale             ;
                Collation       = collation         ?? "";
                IsNullable      = isNullable        ;
    
                SqlTypeInfo typeInfo;
                s_typeInfoLookup.TryGetValue (SystemTypeId, out typeInfo) ;
                if (typeInfo == null)
                {
                    typeInfo = SqlTypeInfo.Empty;    
                }
    
                TypeInfo = typeInfo;
    
                m_asString      = "TD." + FullName  ;
            }
    
            public SqlDbType DbType
            {
                get { return TypeInfo.DbType; }
            }
    
            public Type ClrType
            {
                get { return TypeInfo.ClrType; }
            }
    
            public int DbTypeElementSize
            {
                get { return TypeInfo.DbTypeElementSize; }
            }
    
            public string CsTypeName
            {
                get { return TypeInfo.CsTypeName; }
            }
    
            public MethodInfo GetterMethod
            {
                get { return TypeInfo.GetterMethod; }
            }
    
            public override string ToString()
            {
                return m_asString;
            }
        }
    
        abstract partial class BaseTypedSubObject
        {
            public readonly string          Name        ;
            public readonly TypeDefinition  Type        ;
            public readonly int             Ordinal     ;
            public readonly short           MaxLength   ;
            public readonly byte            Precision   ;
            public readonly byte            Scale       ;
    
            protected BaseTypedSubObject(
                string          name        , 
                TypeDefinition  type        , 
                int             ordinal     , 
                short           maxLength   , 
                byte            precision   , 
                byte            scale        
                )
            {
                Name        = name      ?? "";
                Type        = type      ?? TypeDefinition.Empty;
                Ordinal     = ordinal   ;
                MaxLength   = maxLength ;
                Precision   = precision ;
                Scale       = scale     ;
            }
    
            public string DbTypeAsString ()
            {
                var sb = new StringBuilder(Type.TypeInfo.DbTypeName);
    
                if (Type.TypeInfo.RequiresDimension)
                {
                    if (MaxLength < 0)
                    {
                        sb.Append("(MAX)");                    
                    }
                    else
                    {
                        var elementSize = Math.Max(DbTypeElementSize, 1);
                        var value = MaxLength / elementSize;
                        sb.Append('(');
                        sb.Append(value.ToString(CultureInfo.InvariantCulture));                    
                        sb.Append(')');
                    }
                }
    
                if (Type.DbType == SqlDbType.Decimal)
                {
                        sb.Append('(');
                        sb.Append(Precision.ToString(CultureInfo.InvariantCulture));                    
                        sb.Append(',');
                        sb.Append(Scale.ToString(CultureInfo.InvariantCulture));                    
                        sb.Append(')');                
                }
    
                var isNullable = OnGetNullable ();
                if (isNullable != null)
                {
                    if (isNullable.Value)
                    {
                        sb.Append(" NULL");                    
                    }
                    else
                    {
                        sb.Append(" NOT NULL");                    
                    }
                }
    
                return sb.ToString();
            }
    
            protected abstract bool? OnGetNullable();
    
            public SqlDbType DbType
            {
                get {return Type.DbType;}
            }
    
            public Type ClrType
            {
                get {return Type.ClrType;}
            }
    
            public int DbTypeElementSize
            {
                get { return Type.DbTypeElementSize; }
            }
    
            public string CsTypeName
            {
                get { return Type.CsTypeName;}
            }
    
            public MethodInfo GetterMethod
            {
                get { return Type.GetterMethod; }
            }
        }
    
        sealed partial class ColumnSubObject : BaseTypedSubObject
        {
            public readonly string          Collation   ;
            public readonly bool            IsNullable  ;
            public readonly bool            IsIdentity  ;
            public readonly bool            IsComputed  ;
    
            readonly string                 m_asString  ;
    
            public ColumnSubObject(
                string          name        , 
                TypeDefinition  type        , 
                int             ordinal     , 
                short           maxLength   , 
                byte            precision   , 
                byte            scale       , 
                string          collation   , 
                bool            isNullable  , 
                bool            isIdentity  , 
                bool            isComputed
                ) 
                : base(name, type, ordinal, maxLength, precision, scale)
            {
                Collation   = collation ?? "";
                IsNullable  = isNullable;
                IsIdentity  = isIdentity;
                IsComputed  = isComputed;
    
                m_asString  = "CSO." + Name ;
            }
    
            public override string ToString()
            {
                return m_asString;
            }
    
            protected override bool? OnGetNullable()
            {
                return IsNullable;
            }
        }
    
        sealed partial class ParameterSubObject : BaseTypedSubObject
        {
            public readonly bool            IsOutput    ;
    
            readonly string                 m_asString  ;
    
            public ParameterSubObject(
                string          name        , 
                TypeDefinition  type        , 
                int             ordinal     , 
                short           maxLength   , 
                byte            precision   , 
                byte            scale       ,
                bool            isOutput
                ) 
                : base(name, type, ordinal, maxLength, precision, scale)
            {
                IsOutput    = isOutput  ;
    
                m_asString  = "PSO." + Name ;
            }
    
            public override string ToString()
            {
                return m_asString;
            }
    
            protected override bool? OnGetNullable()
            {
                return null;
            }
        }
    
        sealed partial class SchemaObject
        {
            public enum SchemaObjectType
            {
                Unknown             ,
                StoredProcedure     ,
                Function            ,
                TableFunction       ,
                InlineTableFunction ,
                Table               ,
                View                ,
            }
    
            public readonly string                  Schema      ;
            public readonly string                  Name        ;
            public readonly string                  FullName    ;
            public readonly SchemaObjectType        Type        ;
            public readonly DateTime                CreateDate  ;
            public readonly DateTime                ModifyDate  ;
    
            public readonly ColumnSubObject[]       Columns     ;
            public readonly ParameterSubObject[]    Parameters  ;
    
            readonly string                         m_asString  ;
    
    
            public SchemaObject(
                string                  schema      , 
                string                  name        , 
                SchemaObjectType        type        , 
                DateTime                createDate  , 
                DateTime                modifyDate  ,
                ColumnSubObject[]       columns     ,
                ParameterSubObject[]    parameters  
                )
            {
                Schema          = schema        ?? "";
                Name            = name          ?? "";
                FullName        = Schema + "." + Name;
                Type            = type          ;
                CreateDate      = createDate    ;
                ModifyDate      = modifyDate    ;
    
                Columns         = columns       ?? new ColumnSubObject[0]       ;
                Parameters      = parameters    ?? new ParameterSubObject[0]    ;
    
                m_asString  = "SO." + FullName ;
            }
    
            public override string ToString()
            {
                return m_asString;
            }
        }
    
        sealed partial class Schema
        {
            // As SQL is generally case insensitive we ignore case when looking for objects
            static readonly StringComparer s_keyComparer = StringComparer.OrdinalIgnoreCase;
    
            readonly Dictionary<string, TypeDefinition> m_typeDefinitions   = new Dictionary<string, TypeDefinition> (s_keyComparer);
            readonly Dictionary<string, SchemaObject>   m_schemaObjects     = new Dictionary<string, SchemaObject> (s_keyComparer);
    
            public Schema (SqlConnection connection)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"
    SELECT
    	s.name								[Schema]		,	-- 0
    	t.name								Name			,	-- 1
    	t.system_type_id					SystemTypeId	,	-- 2
    	t.user_type_id						UserTypeId		,	-- 3
    	t.max_length						[MaxLength]		,	-- 4
    	t.[precision]						[Precision]		,	-- 5
    	t.scale								Scale			,	-- 6
    	ISNULL (t.collation_name	, '')	Collation		,	-- 7
    	ISNULL (t.is_nullable		, 0)	IsNullable		 	-- 8
    	FROM SYS.types t WITH(NOLOCK)
    	INNER JOIN SYS.schemas s WITH(NOLOCK) ON t.schema_id = s.schema_id
    
    SELECT 
    	c.object_id							ObjectId	,	-- 0
    	s.name								[TypeSchema],	-- 1
    	t.name								[TypeName]	,	-- 2
    	ISNULL (c.name		, '')			Name		,	-- 3
    	c.column_id							Ordinal		,	-- 4
    	c.max_length						[MaxLength]	,	-- 5
    	c.[precision]						[Precision]	,	-- 6
    	c.scale								Scale		,	-- 7
    	ISNULL (c.collation_name	, '')	Collation	,	-- 8
    	ISNULL (c.is_nullable		, 0)	IsNullable	,	-- 9
    	c.is_identity						IsIdentity	,	-- 10
    	c.is_computed						IsComputed		-- 11
    	FROM SYS.objects o WITH(NOLOCK)
    	INNER JOIN SYS.columns c WITH(NOLOCK) ON o.object_id = c.object_id
    	INNER JOIN SYS.types t WITH(NOLOCK) ON c.user_type_id = t.user_type_id AND c.system_type_id = t.system_type_id
    	INNER JOIN SYS.schemas s WITH(NOLOCK) ON t.schema_id = s.schema_id
    	WHERE
    		o.is_ms_shipped = 0
    
    SELECT 
    	p.object_id							ObjectId	,	-- 0
    	s.name								[TypeSchema],	-- 1
    	t.name								[TypeName]	,	-- 2
    	ISNULL (p.name		, '')			Name		,	-- 3
    	p.parameter_id						Ordinal		,	-- 4
    	p.max_length						[MaxLength]	,	-- 5
    	p.[precision]						[Precision]	,	-- 6
    	p.scale								Scale		,	-- 7
    	p.is_output							IsOutput		-- 8
    	FROM SYS.objects o WITH(NOLOCK)
    	INNER JOIN SYS.parameters p WITH(NOLOCK) ON o.object_id = p.object_id
    	INNER JOIN SYS.types t WITH(NOLOCK) ON p.user_type_id = t.user_type_id AND p.system_type_id = t.system_type_id
    	INNER JOIN SYS.schemas s WITH(NOLOCK) ON t.schema_id = s.schema_id
    	WHERE
    		o.is_ms_shipped = 0
    
    SELECT
    	o.object_id							ObjectId		,	-- 0
    	s.name								[Schema]		,	-- 1
    	o.name								Name			,	-- 2
    	o.[type]							[Type]			,	-- 4
    	o.create_date						CreateDate		,	-- 5
    	o.modify_date						ModifyDate			-- 6
    	FROM SYS.schemas s WITH(NOLOCK)
    	INNER JOIN SYS.objects o WITH(NOLOCK) ON o.schema_id = s.schema_id
    	WHERE
    		o.is_ms_shipped = 0
    		AND
    		o.type IN ('P', 'TF', 'IF', 'F', 'U', 'V')
    ";
    
                    var columnLookup    = new Dictionary<int, List<ColumnSubObject>> ();
                    var parameterLookup = new Dictionary<int, List<ParameterSubObject>> ();
    
                    using (var reader = command.ExecuteReader (CommandBehavior.SequentialAccess))
                    {
                        while (reader.Read ())
                        {
                            var type = new TypeDefinition (
                                reader.GetString(0) , 
                                reader.GetString(1) , 
                                reader.GetByte(2)   , 
                                reader.GetInt32(3)  , 
                                reader.GetInt16(4)  , 
                                reader.GetByte(5)   , 
                                reader.GetByte(6)   , 
                                reader.GetString(7) , 
                                reader.GetBoolean(8) 
                                );
                            m_typeDefinitions[type.FullName] = type;
                        }
    
                        if (!reader.NextResult())
                        {
                            return;                            
                        }
    
                        while (reader.Read ())
                        {
                            var objectId = reader.GetInt32(0);
                            var fullName = reader.GetString(1) + "." + reader.GetString (2);
     
                            var type = FindTypeDefinition (fullName); 
    
                            var column = new ColumnSubObject (
                                reader.GetString(3)   ,
                                type                  ,
                                reader.GetInt32(4)    , 
                                reader.GetInt16(5)    , 
                                reader.GetByte(6)     , 
                                reader.GetByte(7)     , 
                                reader.GetString(8)   , 
                                reader.GetBoolean(9)  , 
                                reader.GetBoolean(10) , 
                                reader.GetBoolean(11) 
                                );
    
                            AddObject (columnLookup, objectId, column);
                        }
    
                        if (!reader.NextResult())
                        {
                            return;                            
                        }
    
                        while (reader.Read ())
                        {
                            var objectId = reader.GetInt32(0);
                            var fullName = reader.GetString(1) + "." + reader.GetString (2);
     
                            var type = FindTypeDefinition (fullName); 
    
                            var parameter = new ParameterSubObject (
                                reader.GetString(3)   ,
                                type                  ,
                                reader.GetInt32(4)    , 
                                reader.GetInt16(5)    , 
                                reader.GetByte(6)     , 
                                reader.GetByte(7)     , 
                                reader.GetBoolean(8)   
                                );
    
                            AddObject (parameterLookup, objectId, parameter);
                        }
    
                        if (!reader.NextResult())
                        {
                            return;                            
                        }
    
                        while (reader.Read ())
                        {
                            var objectId = reader.GetInt32(0);
                            var schema = reader.GetString(1);
                            var name = reader.GetString(2);
                            var fullName = schema + "." + name;
                            var schemaObjectType = ToSchemaType(reader.GetString(3));
                            
                            if (schemaObjectType == SchemaObject.SchemaObjectType.Unknown)
                            {
                                continue;
                            }
    
                            List<ColumnSubObject> columns;
                            List<ParameterSubObject> parameters;
    
                            columnLookup.TryGetValue(objectId, out columns);
                            parameterLookup.TryGetValue(objectId, out parameters);
    
                            var schemaObject = new SchemaObject (
                                schema                      ,
                                name                        ,
                                schemaObjectType            ,
                                reader.GetDateTime(4)       ,
                                reader.GetDateTime(5)       ,
                                NonNull(columns)
                                    .Where(c => c != null)
                                    .OrderBy(c => c.Ordinal)
                                    .ToArray()
                                    ,
                                NonNull(parameters)
                                    .Where(p => p != null)
                                    .OrderBy(p => p.Ordinal)
                                    .ToArray()
                                );
    
                            m_schemaObjects[fullName] = schemaObject;
                        }
    
                    }
    
                    
                }
    
            }
    
            static IEnumerable<T> NonNull<T> (IEnumerable<T> list)
            {
                if (list == null)
                {
                    return new T[0];
                }
                
                return list;
                
            }
    
            SchemaObject.SchemaObjectType ToSchemaType(string schemaType)
            {
                switch ((schemaType ?? "").Trim())
                {
                    case "P":
                        return SchemaObject.SchemaObjectType.StoredProcedure;
                    case "U":
                        return SchemaObject.SchemaObjectType.Table;
                    case "TF":
                        return SchemaObject.SchemaObjectType.TableFunction;
                    case "IF":
                        return SchemaObject.SchemaObjectType.InlineTableFunction;
                    case "F":
                        return SchemaObject.SchemaObjectType.Function;
                    case "V":
                        return SchemaObject.SchemaObjectType.View;
                    default:
                        return SchemaObject.SchemaObjectType.Unknown;
                }
            }
    
            static void AddObject<T> (Dictionary<int, List<T>> dic, int key, T obj)
                where T : class
            {
                if (dic == null)
                {
                    return;
                }
    
                if (obj == null)
                {
                    return;
                }
    
                List<T> list;
                if (!dic.TryGetValue (key, out list))
                {
                    list = new List<T> (16);
                    dic[key] = list;
                }
    
                list.Add(obj);
            }
    
            public IEnumerable<TypeDefinition> TypeDefinitions
            {
                get
                {
                    return m_typeDefinitions.Values;
                }
            }
    
            public TypeDefinition FindTypeDefinition (string fullName)
            {
                TypeDefinition typeDefinition;
                m_typeDefinitions.TryGetValue (fullName ?? "", out typeDefinition);
                return typeDefinition;
            }
    
            public IEnumerable<SchemaObject> SchemaObjects
            {
                get
                {
                    return m_schemaObjects.Values;
                }
            }
    
            public SchemaObject FindSchemaObject (string fullName)
            {
                SchemaObject schemaObject;
                m_schemaObjects.TryGetValue (fullName ?? "", out schemaObject);
                return schemaObject;
            }
        
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\SQL\Schema.cs
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
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Extensions\ParseExtensions.cs
namespace FileInclude
{
    
    
    
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
        using System.Collections.Generic;
        using System.Globalization;
    
        using Source.Common;
    
        static partial class ParseExtensions
        {
            static readonly Dictionary<Type, Func<object>> s_defaultValues = new Dictionary<Type, Func<object>> 
                {
    #if !T4INCLUDE__SUPPRESS_BOOLEAN_PARSE_EXTENSIONS
                    { typeof(Boolean)      , () => default (Boolean)},
                    { typeof(Boolean?)     , () => default (Boolean?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_CHAR_PARSE_EXTENSIONS
                    { typeof(Char)      , () => default (Char)},
                    { typeof(Char?)     , () => default (Char?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_SBYTE_PARSE_EXTENSIONS
                    { typeof(SByte)      , () => default (SByte)},
                    { typeof(SByte?)     , () => default (SByte?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_INT16_PARSE_EXTENSIONS
                    { typeof(Int16)      , () => default (Int16)},
                    { typeof(Int16?)     , () => default (Int16?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_INT32_PARSE_EXTENSIONS
                    { typeof(Int32)      , () => default (Int32)},
                    { typeof(Int32?)     , () => default (Int32?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_INT64_PARSE_EXTENSIONS
                    { typeof(Int64)      , () => default (Int64)},
                    { typeof(Int64?)     , () => default (Int64?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_BYTE_PARSE_EXTENSIONS
                    { typeof(Byte)      , () => default (Byte)},
                    { typeof(Byte?)     , () => default (Byte?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_UINT16_PARSE_EXTENSIONS
                    { typeof(UInt16)      , () => default (UInt16)},
                    { typeof(UInt16?)     , () => default (UInt16?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_UINT32_PARSE_EXTENSIONS
                    { typeof(UInt32)      , () => default (UInt32)},
                    { typeof(UInt32?)     , () => default (UInt32?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_UINT64_PARSE_EXTENSIONS
                    { typeof(UInt64)      , () => default (UInt64)},
                    { typeof(UInt64?)     , () => default (UInt64?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_SINGLE_PARSE_EXTENSIONS
                    { typeof(Single)      , () => default (Single)},
                    { typeof(Single?)     , () => default (Single?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_DOUBLE_PARSE_EXTENSIONS
                    { typeof(Double)      , () => default (Double)},
                    { typeof(Double?)     , () => default (Double?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_DECIMAL_PARSE_EXTENSIONS
                    { typeof(Decimal)      , () => default (Decimal)},
                    { typeof(Decimal?)     , () => default (Decimal?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_TIMESPAN_PARSE_EXTENSIONS
                    { typeof(TimeSpan)      , () => default (TimeSpan)},
                    { typeof(TimeSpan?)     , () => default (TimeSpan?)},
    #endif
    #if !T4INCLUDE__SUPPRESS_DATETIME_PARSE_EXTENSIONS
                    { typeof(DateTime)      , () => default (DateTime)},
                    { typeof(DateTime?)     , () => default (DateTime?)},
    #endif
                };
            static readonly Dictionary<Type, Func<string, CultureInfo, object>> s_parsers = new Dictionary<Type, Func<string, CultureInfo, object>> 
                {
    #if !T4INCLUDE__SUPPRESS_BOOLEAN_PARSE_EXTENSIONS
                    { typeof(Boolean)  , (s, ci) => { Boolean value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Boolean?) , (s, ci) => { Boolean value; return s.TryParse(ci, out value) ? (object)(Boolean?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_CHAR_PARSE_EXTENSIONS
                    { typeof(Char)  , (s, ci) => { Char value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Char?) , (s, ci) => { Char value; return s.TryParse(ci, out value) ? (object)(Char?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_SBYTE_PARSE_EXTENSIONS
                    { typeof(SByte)  , (s, ci) => { SByte value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(SByte?) , (s, ci) => { SByte value; return s.TryParse(ci, out value) ? (object)(SByte?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_INT16_PARSE_EXTENSIONS
                    { typeof(Int16)  , (s, ci) => { Int16 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Int16?) , (s, ci) => { Int16 value; return s.TryParse(ci, out value) ? (object)(Int16?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_INT32_PARSE_EXTENSIONS
                    { typeof(Int32)  , (s, ci) => { Int32 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Int32?) , (s, ci) => { Int32 value; return s.TryParse(ci, out value) ? (object)(Int32?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_INT64_PARSE_EXTENSIONS
                    { typeof(Int64)  , (s, ci) => { Int64 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Int64?) , (s, ci) => { Int64 value; return s.TryParse(ci, out value) ? (object)(Int64?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_BYTE_PARSE_EXTENSIONS
                    { typeof(Byte)  , (s, ci) => { Byte value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Byte?) , (s, ci) => { Byte value; return s.TryParse(ci, out value) ? (object)(Byte?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_UINT16_PARSE_EXTENSIONS
                    { typeof(UInt16)  , (s, ci) => { UInt16 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(UInt16?) , (s, ci) => { UInt16 value; return s.TryParse(ci, out value) ? (object)(UInt16?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_UINT32_PARSE_EXTENSIONS
                    { typeof(UInt32)  , (s, ci) => { UInt32 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(UInt32?) , (s, ci) => { UInt32 value; return s.TryParse(ci, out value) ? (object)(UInt32?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_UINT64_PARSE_EXTENSIONS
                    { typeof(UInt64)  , (s, ci) => { UInt64 value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(UInt64?) , (s, ci) => { UInt64 value; return s.TryParse(ci, out value) ? (object)(UInt64?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_SINGLE_PARSE_EXTENSIONS
                    { typeof(Single)  , (s, ci) => { Single value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Single?) , (s, ci) => { Single value; return s.TryParse(ci, out value) ? (object)(Single?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_DOUBLE_PARSE_EXTENSIONS
                    { typeof(Double)  , (s, ci) => { Double value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Double?) , (s, ci) => { Double value; return s.TryParse(ci, out value) ? (object)(Double?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_DECIMAL_PARSE_EXTENSIONS
                    { typeof(Decimal)  , (s, ci) => { Decimal value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(Decimal?) , (s, ci) => { Decimal value; return s.TryParse(ci, out value) ? (object)(Decimal?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_TIMESPAN_PARSE_EXTENSIONS
                    { typeof(TimeSpan)  , (s, ci) => { TimeSpan value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(TimeSpan?) , (s, ci) => { TimeSpan value; return s.TryParse(ci, out value) ? (object)(TimeSpan?)value : null;}},
    #endif
    #if !T4INCLUDE__SUPPRESS_DATETIME_PARSE_EXTENSIONS
                    { typeof(DateTime)  , (s, ci) => { DateTime value; return s.TryParse(ci, out value) ? (object)value : null;}},
                    { typeof(DateTime?) , (s, ci) => { DateTime value; return s.TryParse(ci, out value) ? (object)(DateTime?)value : null;}},
    #endif
                };
    
            public static bool CanParse (this Type type)
            {
                if (type == null)
                {
                    return false;
                }
    
                return s_parsers.ContainsKey (type);
            }
    
            public static object GetParsedDefaultValue (this Type type)
            {
                type = type ?? typeof (object);
    
                Func<object> getValue;
    
                return s_defaultValues.TryGetValue (type, out getValue) ? getValue () : null;
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, Type type, out object value)
            {
                value = null;
                if (type == null)
                {
                    return false;
                }                
                
                Func<string, CultureInfo, object> parser;
    
                if (s_parsers.TryGetValue (type, out parser))
                {
                    value = parser (s, cultureInfo);
                }
    
                return value != null;
            }
    
            public static bool TryParse (this string s, Type type, out object value)
            {
                return s.TryParse (Config.DefaultCulture, type, out value);
            }
    
            public static object Parse (this string s, CultureInfo cultureInfo, Type type, object defaultValue)
            {
                object value;
                return s.TryParse (cultureInfo, type, out value) ? value : defaultValue;
            }
    
            public static object Parse (this string s, Type type, object defaultValue)
            {
                return s.Parse (Config.DefaultCulture, type, defaultValue);
            }
    
            // Boolean (BoolLike)
    
    #if !T4INCLUDE__SUPPRESS_BOOLEAN_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Boolean value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Boolean Parse (this string s, CultureInfo cultureInfo, Boolean defaultValue)
            {
                Boolean value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Boolean Parse (this string s, Boolean defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Boolean value)
            {
                return Boolean.TryParse (s ?? "", out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_BOOLEAN_PARSE_EXTENSIONS
    
            // Char (CharLike)
    
    #if !T4INCLUDE__SUPPRESS_CHAR_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Char value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Char Parse (this string s, CultureInfo cultureInfo, Char defaultValue)
            {
                Char value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Char Parse (this string s, Char defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Char value)
            {
                return Char.TryParse (s ?? "", out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_CHAR_PARSE_EXTENSIONS
    
            // SByte (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_SBYTE_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out SByte value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static SByte Parse (this string s, CultureInfo cultureInfo, SByte defaultValue)
            {
                SByte value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static SByte Parse (this string s, SByte defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out SByte value)
            {
                return SByte.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_SBYTE_PARSE_EXTENSIONS
    
            // Int16 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_INT16_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Int16 value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Int16 Parse (this string s, CultureInfo cultureInfo, Int16 defaultValue)
            {
                Int16 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int16 Parse (this string s, Int16 defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int16 value)
            {
                return Int16.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_INT16_PARSE_EXTENSIONS
    
            // Int32 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_INT32_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Int32 value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Int32 Parse (this string s, CultureInfo cultureInfo, Int32 defaultValue)
            {
                Int32 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int32 Parse (this string s, Int32 defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int32 value)
            {
                return Int32.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_INT32_PARSE_EXTENSIONS
    
            // Int64 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_INT64_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Int64 value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Int64 Parse (this string s, CultureInfo cultureInfo, Int64 defaultValue)
            {
                Int64 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Int64 Parse (this string s, Int64 defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Int64 value)
            {
                return Int64.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_INT64_PARSE_EXTENSIONS
    
            // Byte (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_BYTE_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Byte value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Byte Parse (this string s, CultureInfo cultureInfo, Byte defaultValue)
            {
                Byte value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Byte Parse (this string s, Byte defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Byte value)
            {
                return Byte.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_BYTE_PARSE_EXTENSIONS
    
            // UInt16 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_UINT16_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out UInt16 value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static UInt16 Parse (this string s, CultureInfo cultureInfo, UInt16 defaultValue)
            {
                UInt16 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static UInt16 Parse (this string s, UInt16 defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out UInt16 value)
            {
                return UInt16.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_UINT16_PARSE_EXTENSIONS
    
            // UInt32 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_UINT32_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out UInt32 value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static UInt32 Parse (this string s, CultureInfo cultureInfo, UInt32 defaultValue)
            {
                UInt32 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static UInt32 Parse (this string s, UInt32 defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out UInt32 value)
            {
                return UInt32.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_UINT32_PARSE_EXTENSIONS
    
            // UInt64 (IntLike)
    
    #if !T4INCLUDE__SUPPRESS_UINT64_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out UInt64 value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static UInt64 Parse (this string s, CultureInfo cultureInfo, UInt64 defaultValue)
            {
                UInt64 value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static UInt64 Parse (this string s, UInt64 defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out UInt64 value)
            {
                return UInt64.TryParse (s ?? "", NumberStyles.Integer, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_UINT64_PARSE_EXTENSIONS
    
            // Single (FloatLike)
    
    #if !T4INCLUDE__SUPPRESS_SINGLE_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Single value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Single Parse (this string s, CultureInfo cultureInfo, Single defaultValue)
            {
                Single value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Single Parse (this string s, Single defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Single value)
            {                                                  
                return Single.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_SINGLE_PARSE_EXTENSIONS
    
            // Double (FloatLike)
    
    #if !T4INCLUDE__SUPPRESS_DOUBLE_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Double value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Double Parse (this string s, CultureInfo cultureInfo, Double defaultValue)
            {
                Double value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Double Parse (this string s, Double defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Double value)
            {                                                  
                return Double.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_DOUBLE_PARSE_EXTENSIONS
    
            // Decimal (FloatLike)
    
    #if !T4INCLUDE__SUPPRESS_DECIMAL_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out Decimal value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static Decimal Parse (this string s, CultureInfo cultureInfo, Decimal defaultValue)
            {
                Decimal value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static Decimal Parse (this string s, Decimal defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out Decimal value)
            {                                                  
                return Decimal.TryParse (s ?? "", NumberStyles.Float, cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_DECIMAL_PARSE_EXTENSIONS
    
            // TimeSpan (TimeSpanLike)
    
    #if !T4INCLUDE__SUPPRESS_TIMESPAN_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out TimeSpan value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static TimeSpan Parse (this string s, CultureInfo cultureInfo, TimeSpan defaultValue)
            {
                TimeSpan value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static TimeSpan Parse (this string s, TimeSpan defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out TimeSpan value)
            {                                                  
                return TimeSpan.TryParse (s ?? "", cultureInfo, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_TIMESPAN_PARSE_EXTENSIONS
    
            // DateTime (DateTimeLike)
    
    #if !T4INCLUDE__SUPPRESS_DATETIME_PARSE_EXTENSIONS
    
            public static bool TryParse (this string s, out DateTime value)
            {
                return s.TryParse (Config.DefaultCulture, out value);
            }
    
            public static DateTime Parse (this string s, CultureInfo cultureInfo, DateTime defaultValue)
            {
                DateTime value;
    
                return s.TryParse (cultureInfo, out value) ? value : defaultValue;
            }
    
            public static DateTime Parse (this string s, DateTime defaultValue)
            {
                return s.Parse (Config.DefaultCulture, defaultValue);
            }
    
            public static bool TryParse (this string s, CultureInfo cultureInfo, out DateTime value)
            {                                                  
                return DateTime.TryParse (s ?? "", cultureInfo, DateTimeStyles.AssumeLocal, out value);
            }
    
    #endif // T4INCLUDE__SUPPRESS_DATETIME_PARSE_EXTENSIONS
    
        }
    }
    
    
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Extensions\ParseExtensions.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Reflection\ClassDescriptor.cs
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
    
    
    namespace Source.Reflection
    {
        using System;
        using System.Collections;
        using System.Collections.Concurrent;
        using System.Collections.Generic;
        using System.Linq;
        using System.Linq.Expressions;
        using System.Reflection;
    
        static class ClassDescriptorExtensions
        {
            public static ClassDescriptor GetClassDescriptor (this Type type)
            {
                return ClassDescriptor.GetClassDescriptor(type);
            }
        }
    
        partial class ClassDescriptor
        {
            static readonly ConcurrentDictionary<Type, ClassDescriptor> s_classDescriptors =
                new ConcurrentDictionary<Type, ClassDescriptor>();
    
            readonly Dictionary<string, MemberDescriptor>           m_memberLookup           ;
    
            public readonly string                                  Name                ;
    
            public readonly MemberDescriptor[]                      Members             ;
            public readonly MemberDescriptor[]                      PublicGetMembers    ;
            public readonly Type                                    Type                ;
            public readonly object[]                                Attributes          ;
    
            public readonly Func<object>                            Creator             ;
            public readonly bool                                    HasCreator          ;
    
            public readonly bool                                    IsNullable          ;
            public readonly Type                                    NonNullableType     ;
    
            public readonly bool                                    IsListLike          ;
            public readonly Type                                    ListItemType        ;
    
            public readonly bool                                    IsDictionaryLike    ;
            public readonly Type                                    DictionaryKeyType   ;
            public readonly Type                                    DictionaryValueType ;
    
            public ClassDescriptor(Type type)
            {
                Type        = type ?? typeof(object);
                Attributes  = Type.GetCustomAttributes(inherit: true);
                Name        = Type.Name;
                Members     = Type.IsPrimitive 
                    ?   new MemberDescriptor[0]
                    :   Type
                        .GetMembers(
                                BindingFlags.Instance
                            |   BindingFlags.Public
                            |   BindingFlags.NonPublic
                            )
                        .Where(mi => mi.MemberType == MemberTypes.Property || mi.MemberType == MemberTypes.Field)
                        .Where(mi => !HasIndexParameters(mi))
                        .Select(mi => new MemberDescriptor(mi))
                        .ToArray()
                        ;
    
                PublicGetMembers= Members.Where (mi => mi.HasPublicGetter).ToArray ();
                m_memberLookup  = Members.ToDictionary (mi => mi.Name);
    
                Creator = GetCreator(Type);
                HasCreator = !ReferenceEquals(Creator, s_defaultCreator);
    
                var isNullableType  = Type.IsGenericType && Type.GetGenericTypeDefinition() == typeof (Nullable<>);;
                IsNullable          = isNullableType || !Type.IsValueType;
                NonNullableType     = isNullableType ? Type.GetGenericArguments()[0] : Type;
    
                IsListLike          = false;
                IsDictionaryLike    = false;
                ListItemType        = typeof (object);
                DictionaryKeyType   = typeof (object);
                DictionaryValueType = typeof (object);
    
                var possibleDictionaryType = AsGenericType(Type, typeof(IDictionary<,>));
                var possibleListType = AsGenericType(Type, typeof(IList<>));
    
                IsDictionaryLike = possibleDictionaryType  != null || typeof (IDictionary).IsAssignableFrom (Type);
                if (possibleDictionaryType != null)
                {
                    var genericArguments = possibleDictionaryType.GetGenericArguments();
                    DictionaryKeyType   = genericArguments[0];
                    DictionaryValueType = genericArguments[1];
                }
    
                IsListLike = possibleListType  != null || typeof (IList).IsAssignableFrom (Type);
                if (possibleListType != null)
                {
                    ListItemType = possibleListType.GetGenericArguments()[0];
                }
            }
    
            static bool HasIndexParameters (MemberInfo mi)
            {
                var pi = mi as PropertyInfo;
                return pi != null && pi.GetIndexParameters().Length > 0;
            }
    
            static Type AsGenericType (Type type, Type asType)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition () == asType)
                {
                    return type;
                }
                
                return type
                    .GetInterfaces()
                    .FirstOrDefault(t =>  t.IsGenericType && t.GetGenericTypeDefinition() == asType)
                    ;
            }
    
            public MemberDescriptor FindMember (string name, bool requirePublicGet = true, bool requirePublicSet = true)
            {
                MemberDescriptor value;
                if (!m_memberLookup.TryGetValue(name ?? "", out value))
                {
                    return null;
                }
    
                return      (!requirePublicGet || value.HasPublicGetter)
                       &&   (!requirePublicSet || value.HasPublicSetter)
                            ?   value
                            :   null
                            ;
            }
    
            Func<object> GetCreator(Type type)
            {
                if (type.IsAbstract || type.IsInterface)
                {
                    return s_defaultCreator;
                }
    
                if (type.IsValueType)
                {
                    return Expression.Lambda<Func<object>>(Expression.Convert (Expression.New(type), typeof(object))).Compile();                
                }
    
                var ci = type
                    .GetConstructors(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic)
                    .FirstOrDefault (c => c.GetParameters ().Length == 0)
                    ;
    
                if (ci == null)
                {
                    return s_defaultCreator;
                }
    
                return Expression.Lambda<Func<object>>(Expression.New(ci)).Compile();
            }
    
            static readonly Func<Type, ClassDescriptor> s_createClassDescriptor = t => new ClassDescriptor(t);
            static readonly Func<object> s_defaultCreator = () => null;
    
            public static ClassDescriptor GetClassDescriptor(Type type)
            {
                return s_classDescriptors.GetOrAdd(
                    type ?? typeof (object),
                    s_createClassDescriptor
                    );
            }
        }
    
        partial class MemberDescriptor
        {
            public readonly string                  Name                ;
    
            public readonly MemberInfo              MemberInfo          ;
            public readonly Type                    MemberType          ;
            public readonly object[]                Attributes          ;
    
            public readonly bool                    HasPublicGetter     ;
            public readonly bool                    HasPublicSetter     ;
    
            public readonly bool                    HasGetter           ;
            public readonly bool                    HasSetter           ;
            public readonly Func<object, object>    Getter              ;
            public readonly Action<object, object>  Setter              ;
    
            ClassDescriptor m_lazyClassDescriptor;
    
            static readonly Func<object, object>    s_defaultGetter    = instance => null  ;
            static readonly Action<object, object>  s_defaultSetter  = (x, v) => { }     ;
    
            public MemberDescriptor(MemberInfo memberInfo)
            {
                if (memberInfo == null)
                {
                    throw new ArgumentNullException("memberInfo");
                }
    
                MemberInfo  = memberInfo;
                Attributes  = MemberInfo.GetCustomAttributes(inherit: true);
                Name        = MemberInfo.Name; 
                Getter      = GetGetter(MemberInfo);
                Setter      = GetSetter(MemberInfo);
    
                HasGetter   = !ReferenceEquals(Getter, s_defaultGetter);
                HasSetter   = !ReferenceEquals(Setter, s_defaultSetter);
    
                var pi = MemberInfo as PropertyInfo;
                var fi = MemberInfo as FieldInfo;
                if (pi != null)
                {
                    MemberType      =   pi.PropertyType                                             ;
                    HasPublicGetter =   HasGetter && pi.GetGetMethod(nonPublic: true).IsPublic   ;
                    HasPublicSetter =   HasSetter && pi.GetSetMethod(nonPublic: true).IsPublic   ;
                }
                else if (fi != null)
                {
                    MemberType      = fi.FieldType;
                    HasPublicGetter    =   HasGetter && fi.IsPublic    ;
                    HasPublicSetter    =   HasSetter && fi.IsPublic    ;
                }
                else
                {
                    MemberType = typeof (object);
                }
    
            }
    
            public ClassDescriptor ClassDescriptor
            {
                get { return m_lazyClassDescriptor ?? (m_lazyClassDescriptor = MemberType.GetClassDescriptor()); }
            }
    
            static Func<object, object> GetGetter(MemberInfo mi)
            {
                var pi = mi as PropertyInfo;
                var fi = mi as FieldInfo;
    
                if (pi != null && pi.GetGetMethod(nonPublic:true) != null && pi.GetGetMethod(nonPublic:true).GetParameters().Length == 0)
                {
                    var instance = Expression.Parameter(typeof(object), "instance");
    
                    var expr = Expression.Lambda<Func<object, object>>(
                        Expression.Convert(
                            Expression.Property(
                                Expression.Convert(instance, pi.DeclaringType ?? typeof(object)), 
                                pi), 
                            typeof(object)),
                        instance);
    
                    return expr.Compile();                
                }
                else if (fi != null)
                {
                    var instance = Expression.Parameter(typeof(object), "instance");
    
                    var expr = Expression.Lambda<Func<object, object>>(
                        Expression.Convert(
                            Expression.Field(
                                Expression.Convert(instance, fi.DeclaringType ?? typeof(object)), fi),
                            typeof(object)),
                        instance);
    
                    return expr.Compile();
                }
                else
                {
                    return s_defaultGetter;
                }
            }
    
            static Action<object, object> GetSetter(MemberInfo mi)
            {
                var pi = mi as PropertyInfo;
                var fi = mi as FieldInfo;
    
                if (pi != null && pi.GetSetMethod(nonPublic:true) != null && pi.GetSetMethod(nonPublic:true).GetParameters().Length == 1)
                {
                    var instance = Expression.Parameter(typeof(object), "instance");
                    var value = Expression.Parameter(typeof(object), "value");
    
                    var expr = Expression.Lambda<Action<object, object>>(
                        Expression.Assign(
                            Expression.Property(Expression.Convert(instance, pi.DeclaringType ?? typeof(object)), pi), 
                            Expression.Convert(value, pi.PropertyType)),
                        instance,
                        value
                        );
    
                    return expr.Compile();
                }
                else if (fi != null && !fi.IsInitOnly)
                {
                    var instance = Expression.Parameter(typeof(object), "instance");
                    var value = Expression.Parameter(typeof(object), "value");
    
                    var expr = Expression.Lambda<Action<object, object>>(
                        Expression.Assign(
                            Expression.Field(Expression.Convert(instance, fi.DeclaringType ?? typeof(object)), fi),
                            Expression.Convert(value, fi.FieldType)),
                        instance,
                        value
                        );
    
                    return expr.Compile();
                }
                else
                {
                    return s_defaultSetter;
                }
            }
    
        }
    
    
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Reflection\ClassDescriptor.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Reflection\StaticReflection.cs
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
    
    namespace Source.Reflection
    {
        using System;
        using System.Linq.Expressions;
        using System.Reflection;
    
        static partial class StaticReflection
        {
            public static MethodInfo GetMethodInfo (Expression<Action> expr)
            {
                return ((MethodCallExpression)expr.Body).Method;
            }
    
            public static MemberInfo GetMemberInfo<TReturn> (Expression<Func<TReturn>> expr)
            {
                return ((MemberExpression)expr.Body).Member;
            }
    
            public static ConstructorInfo GetConstructorInfo<TReturn> (Expression<Func<TReturn>> expr)
            {
                return ((NewExpression)expr.Body).Constructor;
            }
        }
    
        static partial class StaticReflection<T>
        {
            public static MethodInfo GetMethodInfo (Expression<Action<T>> expr)
            {
                return ((MethodCallExpression)expr.Body).Method;
            }
    
            public static MemberInfo GetMemberInfo<TReturn>(Expression<Func<T, TReturn>> expr)
            {
                return ((MemberExpression)expr.Body).Member;
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Reflection\StaticReflection.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Extensions\EnumParseExtensions.cs
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
    
    
    
    namespace Source.Extensions
    {
        using System;
        using System.Collections.Concurrent;
        using System.Reflection;
    
        using Source.Reflection;
    
        static partial class EnumParseExtensions
        {
            enum Dummy {}
    
            sealed partial class EnumParser
            {
                public Func<string, object> ParseEnum   ;
                public Func<object>         DefaultEnum ;
            }
    
            static readonly MethodInfo s_parseEnum = StaticReflection.GetMethodInfo (() => ParseEnum<Dummy>(default (string)));
            static readonly MethodInfo s_genericParseEnum = s_parseEnum.GetGenericMethodDefinition ();
    
            static readonly MethodInfo s_defaultEnum = StaticReflection.GetMethodInfo (() => DefaultEnum<Dummy>());
            static readonly MethodInfo s_genericDefaultEnum = s_defaultEnum.GetGenericMethodDefinition ();
    
            static readonly MethodInfo s_parseNullableEnum = StaticReflection.GetMethodInfo(() => ParseNullableEnum<Dummy>(default(string)));
            static readonly MethodInfo s_genericParseNullableEnum = s_parseNullableEnum.GetGenericMethodDefinition();
    
            static readonly MethodInfo s_defaultNullableEnum = StaticReflection.GetMethodInfo(() => DefaultNullableEnum<Dummy>());
            static readonly MethodInfo s_genericDefaultNullableEnum = s_defaultNullableEnum.GetGenericMethodDefinition();
    
            static readonly ConcurrentDictionary<Type, EnumParser> s_enumParsers = new ConcurrentDictionary<Type, EnumParser>();
            static readonly Func<Type, EnumParser> s_createParser = type => CreateParser (type);
    
            static EnumParser CreateParser(Type type)
            {
                if (type.IsEnum)
                {
                    return new EnumParser
                               {
                                   ParseEnum = (Func<string, object>)Delegate.CreateDelegate(
                                                        typeof(Func<string, object>),
                                                        s_genericParseEnum.MakeGenericMethod(type)
                                                        ),
                                   DefaultEnum = (Func<object>)Delegate.CreateDelegate(
                                                       typeof(Func<object>),
                                                       s_genericDefaultEnum.MakeGenericMethod(type)
                                                       ),
                               };
    
                }
                else if (
                        type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && type.GetGenericArguments()[0].IsEnum
                    )
                {
                    var enumType = type.GetGenericArguments()[0];
                    return new EnumParser
                               {
                                   ParseEnum = (Func<string, object>)Delegate.CreateDelegate(
                                                        typeof(Func<string, object>),
                                                        s_genericParseNullableEnum.MakeGenericMethod(enumType)
                                                        ),
                                   DefaultEnum = (Func<object>)Delegate.CreateDelegate(
                                                       typeof(Func<object>),
                                                       s_genericDefaultNullableEnum.MakeGenericMethod(enumType)
                                                       ),
                               };
    
                }
                else
                {
                    return null;
                }
            }
    
            static object ParseEnum<TEnum>(string value)
                where TEnum : struct
            {
                TEnum result;
                return Enum.TryParse (value, true, out result)
                    ? (object)result
                    : null
                    ;
            }
    
            static object DefaultEnum<TEnum>()
                where TEnum : struct
            {
                return default (TEnum);
            }
    
            static object ParseNullableEnum<TEnum>(string value)
                where TEnum : struct
            {
                TEnum result;
                return Enum.TryParse(value, true, out result)
                    ? (object)(TEnum?)result
                    : null
                    ;
            }
    
            static object DefaultNullableEnum<TEnum>()
                where TEnum : struct
            {
                return default(TEnum?);
            }
    
            public static bool TryParseEnumValue(this string s, Type type, out object value)
            {
                value = null;
                if (string.IsNullOrEmpty (s))
                {
                    return false;
                }
    
                var enumParser = TryGetParser (type);
                if (enumParser == null)
                {
                    return false;
    
                }
                
    
                value = enumParser.ParseEnum (s);
    
                return value != null;
            }
    
            public static bool CanParseEnumValue (this Type type)
            {
                var enumParser = TryGetParser (type);
    
                return enumParser != null;
            }
    
            static EnumParser TryGetParser (Type type)
            {
                if (type == null)
                {
                    return null;
                }
    
                var enumParser = s_enumParsers.GetOrAdd (type, s_createParser);
    
                return enumParser;
            }
    
            public static object ParseEnumValue (this string s, Type type)
            {
                object value;
                return s.TryParseEnumValue (type, out value)
                    ? value
                    : null
                    ;
            }
    
            public static object GetDefaultEnumValue (this Type type)
            {
                var enumParser = TryGetParser (type);
                return enumParser != null ? enumParser.DefaultEnum () : null;
            }
    
            public static TEnum ParseEnumValue<TEnum>(this string s, TEnum defaultValue) 
                where TEnum : struct
            {
                TEnum value;
                return Enum.TryParse (s, true, out value)
                    ? value
                    : defaultValue
                    ;
            }
    
            public static TEnum? ParseEnumValue<TEnum>(this string s)
                where TEnum : struct
            {
                TEnum value;
                return Enum.TryParse(s, true, out value)
                    ? (TEnum?)value
                    : null
                    ;
            }
    
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Extensions\EnumParseExtensions.cs
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
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Log.cs
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
        using System;
        using System.Globalization;
    
        static partial class Log
        {
            static partial void Partial_LogLevel (Level level);
            static partial void Partial_LogMessage (Level level, string message);
            static partial void Partial_ExceptionOnLog (Level level, string format, object[] args, Exception exc);
    
            public static void LogMessage (Level level, string format, params object[] args)
            {
                try
                {
                    Partial_LogLevel (level);
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
                               : string.Format (Config.DefaultCulture, format, args)
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
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Log.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Concurrency\ShutDownable.cs
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
    
    namespace Source.Concurrency
    {
        using System;
    
        using Source.Common;
    
        partial interface IShutDownable : IDisposable
        {
            /// <summary>
            /// SignalShutDown - signals the object to shutdown
            /// Shall not Throw
            /// Shall not Block
            /// </summary>
            void SignalShutDown ();
    
            /// <summary>
            /// ShutDown - waits for the object to shutdown
            /// Should not Throw
            /// May Block
            /// </summary>
            /// <param name="remainingTime"></param>
            void ShutDown (RemainingTime remainingTime);
        }
    
        static partial class ShutDownable
        {
            public static void ShutDown (RemainingTime remainingTime, params IShutDownable[] shutDownables)
            {
                if (shutDownables == null)
                {
                    return;
                }
    
                foreach (var shutDownable in shutDownables)
                {
                    if (shutDownable != null)
                    {
                        shutDownable.SignalShutDown ();
                    }
                }
                
                foreach (var shutDownable in shutDownables)
                {
                    if (shutDownable != null)
                    {
                        try
                        {
                            shutDownable.ShutDown (remainingTime);
                        }
                        catch (Exception exc)
                        {
                            Log.Exception ("Failed to shutdown: {0}", exc);
                        }
                    }
                }
                
            }
                
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Concurrency\ShutDownable.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Concurrency\RemainingTime.cs
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
    
    namespace Source.Concurrency
    {
        using System;
        using System.Diagnostics;
    
        partial struct RemainingTime
        {
            public readonly TimeSpan    TimeOut     ;
            readonly        Stopwatch   m_sw        ;
    
            public RemainingTime (TimeSpan timeOut)
            {
                TimeOut     = timeOut           ;
                m_sw        = new Stopwatch ()  ;
    
                m_sw.Start ();
            }
    
            public TimeSpan Remaining
            {
                get
                {
                    var elapsed = m_sw.Elapsed;
    
                    var remaining = TimeOut - elapsed;
    
                    if (remaining < TimeSpan.Zero)
                    {
                        return TimeSpan.Zero;
                    }
    
                    return remaining;
                }
            }
    
            public bool IsTimedOut
            {
                get
                {
                    return Remaining == TimeSpan.Zero;
                }
            }
            
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Concurrency\RemainingTime.cs
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
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Testing\TestFor.cs
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
    
    
    namespace Source.Testing
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using Source.Common;
        using Source.Extensions;
    
        static partial class TestFor
        {
            public static int FailureCount;
    
            const string NullValue = "<NULL>";
    
            static string ToString(this string v, int start, int count)
            {
                v = v ?? "";
    
                start = start - count/2;
    
                if (start < 0)
                {
                    count += -start;
                    start = 0;
                }
    
                if (start >= v.Length)
                {
                    return "";
                }
    
                count = Math.Min(count, v.Length - start);
    
                return v
                    .Substring(start, count)
                    .Replace("\r", "\\r")
                    .Replace("\t", "\\t")
                    .Replace("\n", "\\n")
                    ;
            }
    
            static bool SequenceEqualityImpl<T>(IEnumerable<T> expected, IEnumerable<T> found, string message)
            {
                object oExpected = expected;
                object oFound = found;
                var finalMessage = "TestFor.SequenceEquality: #EXPECTED:{0}, #FOUND:{1} - {2}"
                    .FormatWith(
                        (oExpected ?? NullValue).GetType().Name,
                        (oFound ?? NullValue).GetType().Name,
                        message
                        );
                try
                {
    
    
                    if (ReferenceEquals(expected, found))
                    {
                        Log.Success(finalMessage);
                        return true;
                    }
    
                    if (oExpected != null && oFound == null)
                    {
                        Log.Error(finalMessage);
                        ++FailureCount;
                        return false;
                    }
    
                    if (oExpected == null && oFound != null)
                    {
                        Log.Error(finalMessage);
                        ++FailureCount;
                        return false;
                    }
    
                    if (expected.Equals(found))
                    {
                        Log.Success(finalMessage);
                        return true;
                    }
    
                    if (expected.SequenceEqual(found))
                    {
                        Log.Success(finalMessage);
                        return true;
                    }
    
                    Log.Error(finalMessage);
                    ++FailureCount;
                    return false;
    
                }
                catch (Exception exc)
                {
                    Log.Exception(finalMessage);
                    Log.Exception("    Caught exception: {0}", exc);
                    ++FailureCount;
                    throw;
                }
            }
    
            static bool EqualityImpl<T> (T expected, T found, string message)
            {
                var sExpected = expected as string;
    
                object oExpected    = expected;
                object oFound       = found;
                if (sExpected != null)
                {
                    var sFound = (oFound ?? NullValue).ToString ();
    
                    var firstDiff = -1;
                    var length = Math.Min(sExpected.Length, sFound.Length);
                    for (var iter = 0; iter < length; ++iter)
                    {
                        if (sExpected[iter] != sFound[iter])
                        {
                            firstDiff = iter;
                            iter = length;
                        }                    
                    }
    
                    if (firstDiff > -1)
                    {
                        ++FailureCount;
                        Log.Error("TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - First diff @{2} - {3}",
                            sExpected.ToString(firstDiff, 16),
                            sFound.ToString(firstDiff, 16),
                            length,
                            message
                            );
                        return false;
                    }
                    else if (sExpected.Length != sFound.Length)
                    {
                        ++FailureCount;
                        Log.Error("TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - Difference in length@{2} - {3}",
                            sExpected.ToString(length, 16),
                            sFound.ToString(length, 16),
                            length,
                            message
                            );
                        return false;
                    }
                    else
                    {
                        Log.Success("TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - {2}",
                            sExpected.ToString(0, 16),
                            sFound.ToString(0, 16),
                            message
                            );
                        return true;
                    }
    
                }
    
                var finalMessage = "TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - {2}"
                    .FormatWith(
                        oExpected ?? NullValue,
                        oFound ?? NullValue,
                        message
                        );
                try
                {
    
    
                    if (ReferenceEquals(expected, found))
                    {
                        Log.Success(finalMessage);
                        return true;
                    }
    
                    if (oExpected != null && oFound == null)
                    {
                        Log.Error(finalMessage);
                        ++FailureCount;
                        return false;
                    }
    
                    if (oExpected == null && oFound != null)
                    {
                        Log.Error(finalMessage);
                        ++FailureCount;
                        return false;
                    }
    
                    if (expected.Equals(found))
                    {
                        Log.Success(finalMessage);
                        return true;
                    }
    
                    Log.Error(finalMessage);
                    ++FailureCount;
                    return false;
    
                }
                catch (Exception exc)
                {
                    Log.Exception(finalMessage);
                    Log.Exception("    Caught exception: {0}", exc);
                    ++FailureCount;
                    throw;
                }
            }
        }
    
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Testing\TestFor.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Text\LineReaderExtensions.cs
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
    
    
    namespace Source.Text
    {
        using System;
        using System.Collections.Generic;
        using System.Text;
    
        sealed partial class Line
        {
            static readonly Line s_empty = new Line('\t', 0, 0, null);
    
            public readonly char Separator;
            public readonly int Offset;
            public readonly int LineNo;
            public readonly string[] Fields;
    
            readonly Lazy<string> m_concatenatedLine;
            readonly Lazy<string> m_toString;
    
            public Line(
                char separator,
                int lineNo,
                int offset,
                string[] fields
                )
            {
                Separator           = separator;
                Offset              = Math.Max(0, offset);
                LineNo              = Math.Max(0, lineNo);
                Fields              = fields ?? new string[0];
    
                m_concatenatedLine  = new Lazy<string>(GetOriginalLine);
                m_toString          = new Lazy<string>(GetToString);
                Offset              = offset;
            }
    
            public static Line Empty
            {
                get { return s_empty; }
            }
    
            public bool IsEmpty
            {
                get
                {
                    return
                            LineNo == 0
                        ||  Fields.Length == 0
                        ||  (Fields.Length == 1 && string.IsNullOrEmpty(Fields[0]))
                        ;
                }
            }
    
            public string ConcatenatedLine
            {
                get
                {
                    return m_concatenatedLine.Value;
                }
            }
    
            public override string ToString()
            {
                return m_toString.Value;
            }
    
            string GetOriginalLine()
            {
                var sb = new StringBuilder();
                var first = true;
    
                foreach (var field in (Fields ?? new string[0]))
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append(Separator);
                    }
                    sb.Append(field ?? "");
                }
    
                return sb.ToString();
            }
    
            string GetToString()
            {
                var sb = new StringBuilder();
    
                sb.Append(LineNo);
                sb.Append('(');
                sb.Append(Offset);
                sb.Append(") - ");
                sb.Append(ConcatenatedLine);
    
                return sb.ToString();
            }
    
        }
    
        static partial class LineExtensionMethods
        {
            [Flags]
            enum ParserState : uint
            {
                OutsideString           = 0x1                               ,
                InsideString            = 0x2                               ,
                OutsideString_Escaped   = OutsideString | Flag_Escaped      ,
                InsideString_Escaped    = InsideString | Flag_Escaped       ,
                Mask_State              = 0xFFFF                            ,
                Mask_Flag               = 0xFFFF0000                        ,
                Flag_Escaped            = 0x10000                           ,
            }
    
            public static IEnumerable<Line> TextToLines(this IEnumerable<char> text, char separator = '\t')
            {
                var currentLine = new List<string>();
                var currentField = new StringBuilder();
    
                var parserState = ParserState.OutsideString;
                var lineNo = 0;
                var offset = 0;
                foreach (var ch in text)
                {
                    switch (parserState)
                    {
                        case ParserState.OutsideString_Escaped:
                        case ParserState.InsideString_Escaped:
                            {
                                switch (ch)
                                {
                                    case 'r':
                                        currentField.Append('\r');
                                        break;
                                    case 'n':
                                        currentField.Append('\n');
                                        break;
                                    case 't':
                                        currentField.Append('\t');
                                        break;
                                    default:
                                        currentField.Append(ch);
                                        break;
                                }
                                parserState = parserState & ParserState.Mask_State;
                            }
                            break;
                        case ParserState.InsideString:
                            {
                                switch (ch)
                                {
                                    case '"':
                                        parserState = ParserState.OutsideString;
                                        break;
                                    case '\\':
                                        parserState = ParserState.InsideString_Escaped;
                                        break;
                                    case '\r':
                                        break;
                                    case '\n':
                                        currentField.Append("\r\n");
                                        break;
                                    default:
                                        currentField.Append(ch);
                                        break;
                                }
                            }
                            break;
                        case ParserState.OutsideString:
                            {
                                if (ch == separator)
                                {
                                    currentLine.Add(currentField.ToString());
                                    currentField.Clear();
                                }
                                else
                                {
                                    switch (ch)
                                    {
                                        case '"':
                                            parserState = ParserState.InsideString;
                                            break;
                                        case '\\':
                                            parserState = ParserState.OutsideString_Escaped;
                                            break;
                                        case '\r':
                                            break;
                                        case '\n':
                                            currentLine.Add(currentField.ToString());
                                            currentField.Clear();
                                            ++lineNo;
                                            yield return new Line(separator, lineNo, offset, currentLine.ToArray());
                                            currentLine.Clear();
                                            break;
                                        default:
                                            currentField.Append(ch);
                                            break;
    
                                    }
                                }
                            }
                            break;
                    }
                    ++offset;
                }
    
                currentLine.Add(currentField.ToString());
                currentField.Clear();
                ++lineNo;
                yield return new Line(separator, lineNo, offset, currentLine.ToArray());
                currentLine.Clear();
    
            }
        }
    
    
    
        partial interface IOriginatedFromLine
        {
            Line GetLine();
            void SetLine(Line line);
        }
    
        abstract partial class BaseOriginatedFromLine : IOriginatedFromLine
        {
            Line m_line;
    
            public void SetLine(Line line)
            {
                m_line = line;
            }
    
            public Line GetLine()
            {
                return m_line ?? Line.Empty;
            }
        }
    
        sealed partial class IgnoreMemberAttribute : Attribute
        {
    
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Text\LineReaderExtensions.cs
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
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
namespace FileInclude
{
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
    #if !NETFX_CORE && !SILVERLIGHT && !WINDOWS_PHONE
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
    #endif
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
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Common\Generated_Log.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\Testing\Generated_TestFor.cs
namespace FileInclude
{
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
    
    
    namespace Source.Testing
    {
        using System;
        using System.Collections.Generic;
    
        partial class TestFor
        {
            public static bool SequenceEquality (IEnumerable<String> expected, IEnumerable<String> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (String expected, String found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Char> expected, IEnumerable<Char> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Char expected, Char found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Boolean> expected, IEnumerable<Boolean> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Boolean expected, Boolean found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<SByte> expected, IEnumerable<SByte> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (SByte expected, SByte found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Int16> expected, IEnumerable<Int16> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Int16 expected, Int16 found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Int32> expected, IEnumerable<Int32> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Int32 expected, Int32 found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Int64> expected, IEnumerable<Int64> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Int64 expected, Int64 found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Byte> expected, IEnumerable<Byte> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Byte expected, Byte found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<UInt16> expected, IEnumerable<UInt16> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (UInt16 expected, UInt16 found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<UInt32> expected, IEnumerable<UInt32> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (UInt32 expected, UInt32 found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<UInt64> expected, IEnumerable<UInt64> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (UInt64 expected, UInt64 found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Single> expected, IEnumerable<Single> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Single expected, Single found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Double> expected, IEnumerable<Double> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Double expected, Double found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<Decimal> expected, IEnumerable<Decimal> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (Decimal expected, Decimal found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<TimeSpan> expected, IEnumerable<TimeSpan> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (TimeSpan expected, TimeSpan found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
            public static bool SequenceEquality (IEnumerable<DateTime> expected, IEnumerable<DateTime> found, string message)
            {
                return SequenceEqualityImpl (expected, found, message);
            }
    
            public static bool Equality (DateTime expected, DateTime found, string message)
            {
                return EqualityImpl (expected, found, message);
            }
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\Testing\Generated_TestFor.cs
// ############################################################################

// ############################################################################
namespace FileInclude.Include
{
    static partial class MetaData
    {
        public const string RootPath        = @"..\..\..";
        public const string IncludeDate     = @"2013-04-07T18:04:49";

        public const string Include_0       = @"C:\temp\GitHub\T4Include\HRON\HRONObjectSerializer.cs";
        public const string Include_1       = @"C:\temp\GitHub\T4Include\HRON\HRONDynamicObjectSerializer.cs";
        public const string Include_2       = @"C:\temp\GitHub\T4Include\Common\ConsoleLog.cs";
        public const string Include_3       = @"C:\temp\GitHub\T4Include\Concurrency\TaskSchedulers.cs";
        public const string Include_4       = @"C:\temp\GitHub\T4Include\Extensions\BasicExtensions.cs";
        public const string Include_5       = @"C:\temp\GitHub\T4Include\Extensions\SqlExtensions.cs";
        public const string Include_6       = @"C:\temp\GitHub\T4Include\Testing\TestRunner.cs";
        public const string Include_7       = @"C:\temp\GitHub\T4Include\Text\LineToObjectExtensions.cs";
        public const string Include_8       = @"C:\temp\GitHub\T4Include\SQL\Schema.cs";
        public const string Include_9       = @"C:\temp\GitHub\T4Include\HRON\HRONSerializer.cs";
        public const string Include_10       = @"C:\temp\GitHub\T4Include\Extensions\ParseExtensions.cs";
        public const string Include_11       = @"C:\temp\GitHub\T4Include\Reflection\ClassDescriptor.cs";
        public const string Include_12       = @"C:\temp\GitHub\T4Include\Reflection\StaticReflection.cs";
        public const string Include_13       = @"C:\temp\GitHub\T4Include\Extensions\EnumParseExtensions.cs";
        public const string Include_14       = @"C:\temp\GitHub\T4Include\Common\Config.cs";
        public const string Include_15       = @"C:\temp\GitHub\T4Include\Common\Log.cs";
        public const string Include_16       = @"C:\temp\GitHub\T4Include\Concurrency\ShutDownable.cs";
        public const string Include_17       = @"C:\temp\GitHub\T4Include\Concurrency\RemainingTime.cs";
        public const string Include_18       = @"C:\temp\GitHub\T4Include\Common\Array.cs";
        public const string Include_19       = @"C:\temp\GitHub\T4Include\Testing\TestFor.cs";
        public const string Include_20       = @"C:\temp\GitHub\T4Include\Text\LineReaderExtensions.cs";
        public const string Include_21       = @"C:\temp\GitHub\T4Include\Common\SubString.cs";
        public const string Include_22       = @"C:\temp\GitHub\T4Include\Common\Generated_Log.cs";
        public const string Include_23       = @"C:\temp\GitHub\T4Include\Testing\Generated_TestFor.cs";
    }
}
// ############################################################################


