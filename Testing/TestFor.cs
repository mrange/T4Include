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

// ### INCLUDE: Generated_TestFor.cs

namespace Source.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Source.Common;
    using Source.Extensions;

    static partial class TestFor
    {
        public static int FailureCount;

        const string NullValue = "<NULL>";

        static string ToString(this string v, int start, int count)
        {
            v = v ?? "";

            start = start - count/2;

            if (start < 0)
            {
                count += -start;
                start = 0;
            }

            if (start >= v.Length)
            {
                return "";
            }

            count = Math.Min(count, v.Length - start);

            return v
                .Substring(start, count)
                .Replace("\r", "\\r")
                .Replace("\t", "\\t")
                .Replace("\n", "\\n")
                ;
        }

        static bool SequenceEqualityImpl<T>(IEnumerable<T> expected, IEnumerable<T> found, string message)
        {
            object oExpected = expected;
            object oFound = found;
            var finalMessage = "TestFor.SequenceEquality: #EXPECTED:{0}, #FOUND:{1} - {2}"
                .FormatWith(
                    (oExpected ?? NullValue).GetType().Name,
                    (oFound ?? NullValue).GetType().Name,
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

        static bool EqualityImpl<T> (T expected, T found, string message)
        {
            var sExpected = expected as string;

            object oExpected    = expected;
            object oFound       = found;
            if (sExpected != null)
            {
                var sFound = (oFound ?? NullValue).ToString ();

                var firstDiff = -1;
                var length = Math.Min(sExpected.Length, sFound.Length);
                for (var iter = 0; iter < length; ++iter)
                {
                    if (sExpected[iter] != sFound[iter])
                    {
                        firstDiff = iter;
                        iter = length;
                    }                    
                }

                if (firstDiff > -1)
                {
                    ++FailureCount;
                    Log.Error("TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - First diff @{2} - {3}",
                        sExpected.ToString(firstDiff, 16),
                        sFound.ToString(firstDiff, 16),
                        length,
                        message
                        );
                    return false;
                }
                else if (sExpected.Length != sFound.Length)
                {
                    ++FailureCount;
                    Log.Error("TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - Difference in length@{2} - {3}",
                        sExpected.ToString(length, 16),
                        sFound.ToString(length, 16),
                        length,
                        message
                        );
                    return false;
                }
                else
                {
                    Log.Success("TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - {2}",
                        sExpected.ToString(0, 16),
                        sFound.ToString(0, 16),
                        message
                        );
                    return true;
                }

            }

            var finalMessage = "TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - {2}"
                .FormatWith(
                    oExpected ?? NullValue,
                    oFound ?? NullValue,
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