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

using System;
using System.Collections.Generic;
using System.Linq;
using FileInclude.Source.Common;
using FileInclude.Source.Extensions;

namespace Test_Functionality
{
    static partial class TestFor
    {
        public static int FailureCount;

        const string NullValue = "<NULL>";

        static bool SequenceEqualityImpl<T>(IEnumerable<T> expected, IEnumerable<T> found, string message, bool suppressValue)
        {
            object oExpected = expected;
            object oFound = found;
            var finalMessage = "TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - {2}"
                .FormatWith(
                    suppressValue ? (oExpected ?? NullValue).GetType().Name : oExpected ?? NullValue,
                    suppressValue ? (oFound ?? NullValue).GetType().Name : oFound ?? NullValue,
                    message
                    );
            try
            {


                if (ReferenceEquals(expected, found))
                {
                    Log.Success(finalMessage);
                    return true;
                }

                if (oExpected != null && oFound == null)
                {
                    Log.Error(finalMessage);
                    ++FailureCount;
                    return false;
                }

                if (oExpected == null && oFound != null)
                {
                    Log.Error(finalMessage);
                    ++FailureCount;
                    return false;
                }

                if (expected.Equals(found))
                {
                    Log.Success(finalMessage);
                    return true;
                }

                if (expected.SequenceEqual(found))
                {
                    Log.Success(finalMessage);
                    return true;
                }

                Log.Error(finalMessage);
                ++FailureCount;
                return false;

            }
            catch (Exception exc)
            {
                Log.Exception(finalMessage);
                Log.Exception("    Caught exception: {0}", exc);
                ++FailureCount;
                throw;
            }
        }

        static bool EqualityImpl<T> (T expected, T found, string message, bool suppressValue)
        {
            object oExpected = expected;
            object oFound = found;
            var finalMessage = "TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - {2}"
                .FormatWith(
                    suppressValue ? (oExpected ?? NullValue).GetType().Name : oExpected ?? NullValue,
                    suppressValue ? (oFound ?? NullValue).GetType().Name : oFound ?? NullValue,
                    message
                    );
            try
            {


                if (ReferenceEquals(expected, found))
                {
                    Log.Success(finalMessage);
                    return true;
                }

                if (oExpected != null && oFound == null)
                {
                    Log.Error(finalMessage);
                    ++FailureCount;
                    return false;
                }

                if (oExpected == null && oFound != null)
                {
                    Log.Error(finalMessage);
                    ++FailureCount;
                    return false;
                }

                if (expected.Equals(found))
                {
                    Log.Success(finalMessage);
                    return true;
                }

                Log.Error(finalMessage);
                ++FailureCount;
                return false;

            }
            catch (Exception exc)
            {
                Log.Exception(finalMessage);
                Log.Exception("    Caught exception: {0}", exc);
                ++FailureCount;
                throw;
            }
        }
    }
}