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

// ### INCLUDE: ../Common/Array.cs
// ### INCLUDE: ../Common/Log.cs

// ReSharper disable InconsistentNaming

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
