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
                MemberType      =   pi.PropertyType                     ;
                HasPublicGetter    =   HasGetter && pi.GetMethod.IsPublic  ;
                HasPublicSetter    =   HasSetter && pi.SetMethod.IsPublic  ;
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

            if (pi != null && pi.GetMethod != null && pi.GetMethod.GetParameters().Length == 0)
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

            if (pi != null && pi.SetMethod != null && pi.SetMethod.GetParameters().Length == 1)
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