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


// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local
// ReSharper disable PartialTypeWithSinglePart

#pragma warning disable 0649

using System;
using System.Collections;
using System.Collections.Generic;
using FileInclude.Source.Extensions;
using FileInclude.Source.Reflection;
using FileInclude.Source.Testing;

namespace Test_Functionality.Reflection
{
    sealed partial class TestsFor_ClassDescriptor
    {
        struct TestCase
        {
            public readonly Type Type               ;
            public readonly bool IsNullable         ;
            public readonly bool IsListLike         ;
            public readonly bool IsDictionaryLike   ;

            public TestCase (
                Type type               ,
                bool isNullable         ,
                bool isListLike         ,
                bool isDictionaryLike   
                )
            {
                Type            = type ?? typeof(object);
                IsNullable      = isNullable            ;
                IsListLike      = isListLike            ;
                IsDictionaryLike= isDictionaryLike      ;

            }
        }                                           

        static readonly TestCase[]   TestCases = 
            new[]
                {
                    TC<int>                             (isNullable:false   , isListLike:false  , isDictionaryLike:false    ),
                    TC<int?>                            (isNullable:true    , isListLike:false  , isDictionaryLike:false    ),
                    TC<object>                          (isNullable:true    , isListLike:false  , isDictionaryLike:false    ),
                    TC<IList<int>>                      (isNullable:true    , isListLike:true   , isDictionaryLike:false    ),
                    TC<IDictionary<string, string[]>>   (isNullable:true    , isListLike:false  , isDictionaryLike:true     ),
                    TC<IList>                           (isNullable:true    , isListLike:true   , isDictionaryLike:false    ),
                    TC<IDictionary>                     (isNullable:true    , isListLike:false  , isDictionaryLike:true     ),
                    TC<List<int>>                       (isNullable:true    , isListLike:true   , isDictionaryLike:false    ),
                    TC<Dictionary<string, string[]>>    (isNullable:true    , isListLike:false  , isDictionaryLike:true     ),
                    TC<ArrayList>                       (isNullable:true    , isListLike:true   , isDictionaryLike:false    ),
                    TC<Hashtable>                       (isNullable:true    , isListLike:false  , isDictionaryLike:true     ),
                };

        static TestCase TC<TType> (bool isNullable, bool isListLike, bool isDictionaryLike)
        {
            return new TestCase(typeof (TType), isNullable, isListLike, isDictionaryLike);
        }

        string GetNegation(bool b)
        {
            return b ? "" : "not ";
        }

        public void Test_Basic()
        {
            foreach (var testCase in TestCases)
            {
                var type = testCase.Type;
                var typeName = type.Name;

                var classDescriptor = ClassDescriptor.GetClassDescriptor(type);

                TestFor.Equality(
                    testCase.IsNullable,
                    classDescriptor.IsNullable,
                    "{0} should {1}be nullable".FormatWith(typeName, GetNegation(testCase.IsNullable))
                    );

                TestFor.Equality(
                    testCase.IsListLike,
                    classDescriptor.IsListLike, 
                    "{0} should {1}be list like".FormatWith(typeName, GetNegation(testCase.IsListLike))
                    );

                TestFor.Equality(
                    testCase.IsDictionaryLike,
                    classDescriptor.IsDictionaryLike,
                    "{0} should not {1}dictionary like".FormatWith(typeName, GetNegation(testCase.IsDictionaryLike))
                    );
            }

        }
   }

}