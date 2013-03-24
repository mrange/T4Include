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

// ### INCLUDE: LineReaderExtensions.cs
// ### INCLUDE: ../Extensions/BasicExtensions.cs
// ### INCLUDE: ../Reflection/ClassDescriptor.cs

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