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

using FileInclude.Source.Testing;
// ReSharper disable InconsistentNaming



namespace Test_Functionality.T4
{
    sealed partial class TestsFor_NamedTuple
    {
        const string BasicTupleAsString = @"Test_Functionality.T4.Session";

        const string StructuralTupleAsString = 
@"{
    !Type           = Customer
    Id              = 10
    FirstName       = ""A.""
    LastName        = ""Tester""
    Aliases         = 
        [
            [000] = ""Another""
            [001] = ""Any""
        ]
    InvoiceAddress  = 
        {
            !Type    = Address
            Id       = 100
            CareOf   = null
            Address1 = ""My street""
            Address2 = null
            Address3 = null
            Address4 = null
            City     = ""My hometown""
            Zip      = ""000HOME""
            County   = null
            Country  = ""The Motherland""
        }
    DeliveryAddress = 
        {
            !Type    = Address
            Id       = 101
            CareOf   = ""My mom""
            Address1 = ""My mom's street""
            Address2 = null
            Address3 = null
            Address4 = null
            City     = ""My mom's hometown""
            Zip      = ""001HOME""
            County   = null
            Country  = ""The Motherland""
        }
}
";

        public void Test_BasicTuple ()
        {
            var one = new Session
            {
                Id       = 101          ,
                ClientIp = "192.168.0.1",
            };

            var two = new Session
            {
                Id       = 101          ,
                ClientIp = "192.168.0.1",
            };

            var three = new Session
            {
                Id       = 201          ,
                ClientIp = "192.168.0.2",
            };

            var asString = one.ToString ();
            TestFor.Equality (BasicTupleAsString, asString, "Tuple.ToString must match");

            TestFor.Equality (true  , one.Equals(one)   , "Identical tuples must match");

            TestFor.Equality (false , one.Equals(two)   , "Structural identical tuples must not match");
            TestFor.Equality (false , two.Equals(one)   , "Structural identical tuples must not match");

            TestFor.Equality (false , one.Equals(three) , "Structural non-identical tuples must not match");
            TestFor.Equality (false , three.Equals(one) , "Structural non-identical tuples must not match");

            TestFor.Equality (true  , one.GetHashCode() == one.GetHashCode()    , "Identical tuples must have same hash code");

            TestFor.Equality (false , one.GetHashCode() == two.GetHashCode()    , "Structural identical tuples must not have same hash code");
            TestFor.Equality (false , two.GetHashCode() == one.GetHashCode()    , "Structural identical tuples must not have same hash code");

            TestFor.Equality (false , one.GetHashCode() == three.GetHashCode()  , "Structural non-identical tuples must not have same hash code");
            TestFor.Equality (false , three.GetHashCode() == one.GetHashCode()  , "Structural non-identical tuples must not have same hash code");

        }

        public void Test_StructuralTuple ()
        {
            var one = new Customer
            {
                Id          = 10L           ,
                FirstName   = "A."          ,
                LastName    = "Tester"      ,
                Aliases     = new [] {"Another", "Any"},
                InvoiceAddress = 
                    new Address
                    {
                        Id       = 100L         ,
                        Address1 = "My street"  ,
                        Zip      = "000HOME"    ,
                        City     = "My hometown",
                        Country  = "The Motherland"
                    },
                DeliveryAddress = 
                    new Address
                    {
                        Id       = 101L                 ,
                        CareOf   = "My mom"             ,
                        Address1 = "My mom's street"    ,
                        Zip      = "001HOME"            ,
                        City     = "My mom's hometown"  ,
                        Country  = "The Motherland"
                    }
                
            };

            var two = new Customer
            {
                Id          = 10L           ,
                FirstName   = "A."          ,
                LastName    = "Tester"      ,
                Aliases     = new [] {"Another", "Any"},
                InvoiceAddress = 
                    new Address
                    {
                        Id       = 100L         ,
                        Address1 = "My street"  ,
                        Zip      = "000HOME"    ,
                        City     = "My hometown",
                        Country  = "The Motherland"
                    },
                DeliveryAddress = 
                    new Address
                    {
                        Id       = 101L                 ,
                        CareOf   = "My mom"             ,
                        Address1 = "My mom's street"    ,
                        Zip      = "001HOME"            ,
                        City     = "My mom's hometown"  ,
                        Country  = "The Motherland"
                    }
                
            };

            var three = new Customer
            {
                Id          = 10L           ,
                FirstName   = "A."          ,
                LastName    = "Tester"      ,
                Aliases     = new [] {"Another", "Any"},
                InvoiceAddress = 
                    new Address
                    {
                        Id       = 200L         ,
                        Address1 = "My street"  ,
                        Zip      = "000HOME"    ,
                        City     = "My hometown",
                        Country  = "The Motherland"
                    },
                DeliveryAddress = 
                    new Address
                    {
                        Id       = 201L                 ,
                        CareOf   = "My mom"             ,
                        Address1 = "My mom's street"    ,
                        Zip      = "001HOME"            ,
                        City     = "My mom's hometown"  ,
                        Country  = "The Motherland"
                    }
                
            };

            var four = new Customer
            {
                Id          = 20L           ,
                FirstName   = "A."          ,
                LastName    = "Tester"      ,
                Aliases     = new [] {"Another", "Any"},
                InvoiceAddress = 
                    new Address
                    {
                        Id       = 200L         ,
                        Address1 = "My street"  ,
                        Zip      = "000HOME"    ,
                        City     = "My hometown",
                        Country  = "The Motherland"
                    },
                DeliveryAddress = 
                    new Address
                    {
                        Id       = 201L                 ,
                        CareOf   = "My mom"             ,
                        Address1 = "My mom's street"    ,
                        Zip      = "001HOME"            ,
                        City     = "My mom's hometown"  ,
                        Country  = "The Motherland"
                    }
                
            };

            var asString = one.ToString ();
            TestFor.Equality (StructuralTupleAsString, asString, "Tuple.ToString must match");

            TestFor.Equality (true  , one.Equals(one)   , "Identical tuples must match");

            TestFor.Equality (true  , one.Equals(two)   , "Structural identical tuples must match");
            TestFor.Equality (true  , two.Equals(one)   , "Structural identical tuples must match");

            TestFor.Equality (false , one.Equals(three) , "Structural non-identical tuples must not match");
            TestFor.Equality (false , three.Equals(one) , "Structural non-identical tuples must not match");

            TestFor.Equality (false , one.Equals(four)  , "Structural non-identical tuples must not match");
            TestFor.Equality (false , four.Equals(one)  , "Structural non-identical tuples must not match");

        
            TestFor.Equality (true  , one.GetHashCode() == one.GetHashCode()    , "Identical tuples must have same hash code");

            TestFor.Equality (true  , one.GetHashCode() == two.GetHashCode()    , "Structural identical tuples must have same hash code");
            TestFor.Equality (true  , two.GetHashCode() == one.GetHashCode()    , "Structural identical tuples must have same hash code");

            TestFor.Equality (false , one.GetHashCode() == three.GetHashCode()  , "Structural non-identical tuples must not have same hash code");
            TestFor.Equality (false , three.GetHashCode() == one.GetHashCode()  , "Structural non-identical tuples must not have same hash code");
        
            TestFor.Equality (false , one.GetHashCode() == four.GetHashCode()   , "Structural non-identical tuples must not have same hash code");
            TestFor.Equality (false , four.GetHashCode() == one.GetHashCode()   , "Structural non-identical tuples must not have same hash code");
        
        }

    }
}
