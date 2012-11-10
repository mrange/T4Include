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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    partial class ClassDescriptor
    {
        static readonly ConcurrentDictionary<Type, ClassDescriptor> s_classDescriptors =
            new ConcurrentDictionary<Type, ClassDescriptor>();

        public readonly Type Type;
        public readonly Func<object> Creator;
        public readonly Dictionary<string, MemberDescriptor> Members;
        public readonly bool HasCreator;

        public ClassDescriptor(Type type)
        {
            Type = type ?? typeof(object);
            Members = Type
                .GetMembers(
                        BindingFlags.Instance
                    |   BindingFlags.Public
                    |   BindingFlags.NonPublic
                    )
                .Where(mi => mi.MemberType == MemberTypes.Property || mi.MemberType == MemberTypes.Field)
                .Select(mi => new MemberDescriptor(mi))
                .ToDictionary(mi => mi.MemberInfo.Name)
                ;
            Creator = GetCreator(type);
            HasCreator = !ReferenceEquals(Creator, s_defaultCreator);
        }

        Func<object> GetCreator(Type type)
        {
            if (type.IsAbstract || type.IsInterface)
            {
                return s_defaultCreator;
            }

            var ci = type
                .GetConstructors(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic)
                .FirstOrDefault (c => c.GetParameters ().Length == 0)
                ;
            if (ci == null)
            {
                return s_defaultCreator;
            }

            var expr = Expression.Lambda<Func<object>>(Expression.New(ci));

            return expr.Compile();
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
        public readonly MemberInfo MemberInfo;
        public readonly Func<object, object> Getter;
        public readonly Action<object, object> Setter;
        public readonly Type MemberType;

        public readonly bool HasGetter;
        public readonly bool HasSetter;
        static readonly Func<object, object> s_defaultGetter = instance => null;
        static readonly Action<object, object> s_defaultSetter = (x,v) => {};

        public MemberDescriptor(MemberInfo mi)
        {
            MemberInfo = mi;
            Getter = GetGetter(mi);
            Setter = GetSetter(mi);
            var pi = mi as PropertyInfo;
            var fi = mi as FieldInfo;
            if (pi != null)
            {
                MemberType = pi.PropertyType;
            }
            else if (fi != null)
            {
                MemberType = fi.FieldType;
            }
            else
            {
                MemberType = typeof (object);
            }

            HasGetter = !ReferenceEquals(Getter, s_defaultGetter);
            HasSetter = !ReferenceEquals(Setter, s_defaultSetter);
        }

        static Func<object, object> GetGetter(MemberInfo mi)
        {
            var pi = mi as PropertyInfo;
            var fi = mi as FieldInfo;

            if (pi != null && pi.GetMethod != null)
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

            if (pi != null && pi.SetMethod != null)
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