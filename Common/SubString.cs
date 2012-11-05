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
// ReSharper disable RedundantCaseLabel

namespace Source.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;


    static class SubStringExtensions
    {
        public static void Append (this StringBuilder sb, SubString ss)
        {
            sb.Append(ss.BaseString, ss.Begin, ss.Length);
        }

        public static void AppendLine(this StringBuilder sb, SubString ss)
        {
            sb.Append(ss.BaseString, ss.Begin, ss.Length);
            sb.AppendLine();
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
            return new SubString(value.BaseString, begin + value.Begin, count);
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

        public SubString(string baseString, int begin, int count) : this()
        {
            m_baseString = baseString;
            var length = BaseString.Length;

            var end = begin + count;

            begin = Clamp(begin, 0, length);
            end = Clamp(end, 0, length);

            if (begin < end)
            {
                m_begin = begin;
                m_end = end;
            }
            else
            {
                m_begin = end;
                m_end = begin;
            }
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

                return BaseString[idx - Begin];
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