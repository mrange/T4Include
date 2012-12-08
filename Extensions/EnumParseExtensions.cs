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

// ### INCLUDE: ../Reflection/StaticReflection.cs

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

        static readonly ConcurrentDictionary<Type, EnumParser> s_enumParsers = new ConcurrentDictionary<Type, EnumParser>();
        static readonly Func<Type, EnumParser> s_createParser = type => CreateParser (type);

        static EnumParser CreateParser (Type type)
        {
            if (!type.IsEnum)
            {
                return null;
            }

            return new EnumParser
                       {
                           ParseEnum    = (Func<string, object>)Delegate.CreateDelegate (
                                                typeof (Func<string, object>),
                                                s_genericParseEnum.MakeGenericMethod (type)
                                                ),
                           DefaultEnum  = (Func<object>)Delegate.CreateDelegate (
                                               typeof (Func<object>),
                                               s_genericDefaultEnum.MakeGenericMethod (type)
                                               ), 
                       };
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

        public static bool TryParseEnumValue (this string s, Type type, out object value)
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

    }
}
