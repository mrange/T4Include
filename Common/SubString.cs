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
                    break;
                case ParseLineState.ConsumedCR:
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
            m_baseString = subString.BaseString;
            var length = subString.Length;

            begin = Clamp(begin, 0, length);
            count = Clamp(count, 0, length - begin);

            var end = begin + count;

            m_begin = subString.Begin + begin;
            m_end = subString.Begin + end;
        }

        public SubString(string baseString, int begin, int count) : this()
        {
            m_baseString = baseString;
            var length = BaseString.Length;

            begin = Clamp(begin, 0, length);
            count = Clamp(count, 0, length - begin);

            var end = begin + count;

            m_begin = begin;
            m_end = end;
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