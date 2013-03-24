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

namespace Test_Functionality.T4
{
    sealed partial class TestsFor_WPFT4
    {
        public void Test_TestControl()
        {
            var testControl = new TestControl {IsValid = true};

            const string testPropertyValue = "TEST";
            TestControl.SetAdditional(testControl, testPropertyValue);

            TestFor.Equality(1, testControl.IsValidCalledCount, "IsValidCalledCount must be 1");
            TestFor.Equality(testPropertyValue, TestControl.GetAdditional(testControl), "Additional property must be {0}".FormatWith(testPropertyValue));
        }
    }
}
