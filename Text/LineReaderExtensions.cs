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

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

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
