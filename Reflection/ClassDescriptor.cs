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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;

    partial class ClassDescriptor
    {
        static readonly ConcurrentDictionary<Type, ClassDescriptor> s_classDescriptors =
            new ConcurrentDictionary<Type, ClassDescriptor>();

        public readonly Type Type;
        public readonly Func<object> Creator;
        public readonly Dictionary<string, MemberDescriptor> Members;

        public ClassDescriptor(Type type)
        {
            Type = type ?? typeof(object);
            Members = Type
                .GetMembers(
                        BindingFlags.Instance
                    |   BindingFlags.Static
                    |   BindingFlags.Public
                    |   BindingFlags.NonPublic
                    )
                .Select(mi => new MemberDescriptor(mi))
                .ToDictionary(mi => mi.MemberInfo.Name)
                ;
            Creator = GetCreator(type);
        }

        Func<object> GetCreator(Type type)
        {
            var ci = type
                .GetConstructors(BindingFlags.Public|BindingFlags.NonPublic)
                .FirstOrDefault (c => c.GetParameters ().Length == 0)
                ;
            if (ci == null)
            {
                return () => FormatterServices.GetUninitializedObject(type);
            }

            var expr = Expression.Lambda<Func<object>>(Expression.New(ci));

            return expr.Compile();
        }

        static readonly Func<Type, ClassDescriptor> s_createClassDescriptor = t => new ClassDescriptor(t);
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

        public MemberDescriptor(MemberInfo mi)
        {
            MemberInfo = mi;
            Getter = GetGetter(mi);
            Setter = GetSetter(mi);
        }

        Func<object, object> GetGetter(MemberInfo mi)
        {
            var pi = mi as PropertyInfo;
            var fi = mi as FieldInfo;

            if (pi != null && pi.GetMethod != null)
            {
                var instance = Expression.Parameter(typeof(object), "instance");

                var expr = Expression.Lambda<Func<object, object>>(
                    Expression.Property(Expression.Convert(instance, pi.DeclaringType), pi),
                    instance);

                return expr.Compile();                
            }
            else if (fi != null)
            {
                var instance = Expression.Parameter(typeof(object), "instance");

                var expr = Expression.Lambda<Func<object, object>>(
                    Expression.Field(Expression.Convert(instance, fi.DeclaringType), fi),
                    instance);

                return expr.Compile();
            }
            else
            {
                return instance => null;
            }
        }

        Action<object, object> GetSetter(MemberInfo mi)
        {
            var pi = mi as PropertyInfo;
            var fi = mi as FieldInfo;

            if (pi != null && pi.SetMethod != null)
            {
                var instance = Expression.Parameter(typeof(object), "instance");
                var value = Expression.Parameter(typeof(object), "value");

                var expr = Expression.Lambda<Action<object, object>>(
                    Expression.Assign(
                        Expression.Property (Expression.Convert(instance, pi.DeclaringType), pi), 
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
                        Expression.Field(Expression.Convert(instance, fi.DeclaringType), fi),
                        Expression.Convert(value, fi.FieldType)),
                    instance,
                    value
                    );

                return expr.Compile();
            }
            else
            {
                return (x,v) => {};
            }
        }

    }


}