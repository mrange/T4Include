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

    static partial class StaticReflection<T>
    {
        public static MethodInfo GetMethodInfo (Expression<Action<T>> expr)
        {
            return ((MethodCallExpression)expr.Body).Method;
        }

        public static MethodInfo GetMethodInfo(Expression<Action> expr)
        {
            return ((MethodCallExpression)expr.Body).Method;
        }

        public static MemberInfo GetMemberInfo<TReturn>(Expression<Func<T, TReturn>> expr)
        {
            return ((MemberExpression)expr.Body).Member;
        }

        public static MemberInfo GetMemberInfo<TReturn>(Expression<Func<TReturn>> expr)
        {
            return ((MemberExpression)expr.Body).Member;
        }

        public static ConstructorInfo GetConstructorInfo<TReturn>(Expression<Func<TReturn>> expr)
        {
            return ((NewExpression)expr.Body).Constructor;
        }
    }
}
