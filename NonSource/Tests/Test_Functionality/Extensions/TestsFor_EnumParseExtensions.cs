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

using FileInclude.Source.Extensions;
using FileInclude.Source.Testing;

namespace Test_Functionality.Extensions
{
    sealed partial class TestsFor_EnumParseExtensions
    {
        enum TestEnum
        {
            X,
            MultiCharacter,
        }

        public void Test_EnumParsing ()
        {
            {
                var canParseTestEnum = typeof (TestEnum).CanParseEnumValue();
                if (TestFor.Equality(true, canParseTestEnum, "TestEnum must be parsable"))
                {
                    object parsedValue;
                    var parseResult = "X".TryParseEnumValue(typeof (TestEnum), out parsedValue);
                    if (
                            TestFor.Equality(true, parseResult, "X must be parsable")
                        &&  TestFor.Equality (true, parsedValue != null, "Parsed value must not be null")
                        &&  TestFor.Equality(true, parsedValue.GetType() == typeof(TestEnum), "Parsed value must be TestEnum")
                        )
                    {
                        TestFor.Equality((int)TestEnum.X, (int)(TestEnum)parsedValue, "X must be parsable");                                               
                    }
                    var noParseResult = "None".TryParseEnumValue(typeof(TestEnum), out parsedValue);
                    TestFor.Equality(false, noParseResult, "None must fail to parse");
                    TestFor.Equality(false, parsedValue != null, "None must fail to parse");
                }


                var x = "X".ParseEnumValue(TestEnum.X);
                TestFor.Equality((int) TestEnum.X, (int) x, "X must be parsable");

                var multiCharacter = "MultiCharacter".ParseEnumValue(TestEnum.X);
                TestFor.Equality((int) TestEnum.MultiCharacter, (int) multiCharacter, "MultiCharacter must be parsable");

                var canParseTestNullableEnum = typeof(TestEnum?).CanParseEnumValue();
                if (TestFor.Equality(true, canParseTestNullableEnum, "TestEnum? must be parsable"))
                {
                    object parsedValue;
                    var parseResult = "X".TryParseEnumValue(typeof(TestEnum?), out parsedValue);
                    if (
                            TestFor.Equality(true, parseResult, "X must be parsable")
                        &&  TestFor.Equality(true, parsedValue != null, "Parsed value must not be null")
                        &&  TestFor.Equality(true, parsedValue.GetType() == typeof(TestEnum), "Parsed value must be TestEnum?")
                        )
                    {
                        TestFor.Equality((int)TestEnum.X, (int)((TestEnum?)parsedValue).Value, "X must be parsable");
                    }

                    var noParseResult = "None".TryParseEnumValue(typeof(TestEnum?), out parsedValue);
                    TestFor.Equality(false, noParseResult, "None must fail to parse");
                    TestFor.Equality(false, parsedValue != null, "None must fail to parse");
                }

                var nx = "X".ParseEnumValue<TestEnum>();
                if (TestFor.Equality(true, nx.HasValue, "X must be parsable"))
                {
                    TestFor.Equality((int)TestEnum.X, (int)nx.Value, "X must be parsable");                    
                }

                var nmultiCharacter = "MultiCharacter".ParseEnumValue<TestEnum>();
                if (TestFor.Equality(true, nmultiCharacter.HasValue, "MultiCharacter must be parsable"))
                {
                    TestFor.Equality((int)TestEnum.MultiCharacter, (int)nmultiCharacter.Value, "MultiCharacter must be parsable");
                }


            }
        }
    }
}
