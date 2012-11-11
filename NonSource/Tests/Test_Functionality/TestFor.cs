using System;
using System.Collections;
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
        public static bool Equality (object expected, object found, string message, bool suppressValue = false)
        {            
            var finalMessage = "TestFor.Equality: #EXPECTED:{0}, #FOUND:{1} - {2}"
                .FormatWith(
                    suppressValue ? (expected ?? new object()).GetType().Name: expected ?? NullValue,
                    suppressValue ? (found ?? new object()).GetType().Name : found ?? NullValue,
                    message
                    );
            try
            {


                if (ReferenceEquals(expected, found))
                {
                    Log.Success(finalMessage);
                    return true;
                }

                if (expected != null && found == null)
                {
                    Log.Error(finalMessage);
                    ++FailureCount;
                    return false;
                }

                if (expected == null && found != null)
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

                var sExpected = expected as IStructuralEquatable;
                var sFound = found as IStructuralEquatable;

                if (sExpected != null && sFound != null && sExpected.Equals(sFound, EqualityComparer<object>.Default))
                {
                    Log.Success(finalMessage);
                    return true;
                }

                var eExpected = expected as IEnumerable;
                var eFound = found as IEnumerable;

                if (eExpected != null && eFound != null && eExpected.Cast<object>().SequenceEqual(eFound.Cast<object>()))
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