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


// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





namespace Test_Functionality.T4
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

#if !SUPPRESS_NAMED_TUPLE_COMMON
    partial interface INamedTuple
    {
        void ToString (StringBuilder sb, int indent);
    }

    static partial class NamedTupleCommon
    {
        public static readonly  IEqualityComparer   DefaultComparer         = EqualityComparer<object>.Default  ;
        public const            int                 DefaultHashCode         = 0x55555555                        ;
        public const            StringComparison    DefaultStringComparison = StringComparison.Ordinal          ;

        public static bool StructuralEqual (IStructuralEquatable left, IStructuralEquatable right)
        {
            if (left != null && right != null)
            {
                return left.Equals (right, DefaultComparer);
            }
            else
            {
                return left == null && right == null;
            }
        }

        public static int StructuralGetHashCode (IStructuralEquatable v)
        {
            if (v == null)
            {
                return DefaultHashCode;
            }

            return v.GetHashCode (DefaultComparer);
        }

        public static void AppendReferenceLine<T> (StringBuilder sb, T value, int indent)
            where T : class
        {
            var nt = value as INamedTuple;
            var e = value as IEnumerable;
            if (nt != null)
            {
                sb.AppendLine ();
                nt.ToString (sb, indent + 4);
            }
            else if (e != null)
            {
                sb.AppendLine ();
                sb.Append (' ', indent + 4);
                sb.AppendLine ("[");
                var idx = -1;
                foreach (var obj in e)
                {
                    ++idx;
                    sb.Append (' ', indent + 8);
                    sb.Append ('[');
                    sb.Append (idx.ToString ("000"));
                    sb.Append ("] = ");

                    var s = obj as string;
                    if (s != null)
                    {
                        AppendStringLine (sb, s, indent + 8);
                    }
                    else
                    {
                        AppendReferenceLine (sb, obj, indent + 8);
                    }
                }
                sb.Append (' ', indent + 4);
                sb.AppendLine ("]");
            }
            else if (value == null)
            {
                sb.AppendLine ("null");
            }
            else
            {
                sb.Append (value);
                sb.AppendLine ();
            }
        }

        public static void AppendValueLine<T> (StringBuilder sb, T value, int indent)
            where T : struct
        {
            sb.Append (value);
            sb.AppendLine ();
        }

        public static void AppendStringLine (StringBuilder sb, string value, int indent)
        {
            if (value == null)
            {
                sb.AppendLine ("null");
            }
            else
            {
                sb.Append ('"');
                sb.Append (value);
                sb.Append ('"');
                sb.AppendLine ();
            }
        }

    } 
#endif


    sealed partial class Customer : IEquatable<Customer>, INamedTuple
    {


        public long     Id              { get; set; }
        public string   FirstName       { get; set; }
        public string   LastName        { get; set; }
        public string[] Aliases         { get; set; }
        public Address  InvoiceAddress  { get; set; }
        public Address  DeliveryAddress { get; set; }

        #region Generated code

        public void ToString (StringBuilder sb, int indent)
        {
            sb.Append (' ', indent);
            var innerIndent = indent + 4;
            sb.AppendLine ("{");

            sb.Append (' ', innerIndent);
            sb.Append ("!Type           = ");
            sb.AppendLine (GetType ().Name);

            sb.Append (' ', innerIndent);
            sb.Append ("Id              = ");
            NamedTupleCommon.AppendValueLine (sb, Id, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("FirstName       = ");
            NamedTupleCommon.AppendStringLine (sb, FirstName, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("LastName        = ");
            NamedTupleCommon.AppendStringLine (sb, LastName, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("Aliases         = ");
            NamedTupleCommon.AppendReferenceLine (sb, Aliases, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("InvoiceAddress  = ");
            NamedTupleCommon.AppendReferenceLine (sb, InvoiceAddress, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("DeliveryAddress = ");
            NamedTupleCommon.AppendReferenceLine (sb, DeliveryAddress, innerIndent);
            sb.Append (' ', indent);
            sb.AppendLine ("}");
        }

        public override string ToString ()
        {
            var sb = new StringBuilder ();

            ToString (sb, 0);

            return sb.ToString ();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Customer);
        }

        public bool Equals (Customer other)
        {
            if (other == null)
            {
                return false;
            }

            var result = 
                    (Id.Equals (other.Id))
                &&  ((FirstName ?? "").Equals (other.FirstName ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((LastName ?? "").Equals (other.LastName ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  (NamedTupleCommon.StructuralEqual (Aliases, other.Aliases))
                &&  (InvoiceAddress == null && other.InvoiceAddress == null || InvoiceAddress != null && other.InvoiceAddress != null && InvoiceAddress.Equals (other.InvoiceAddress))
                &&  (DeliveryAddress == null && other.DeliveryAddress == null || DeliveryAddress != null && other.DeliveryAddress != null && DeliveryAddress.Equals (other.DeliveryAddress))
                ;

            return result;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = NamedTupleCommon.DefaultHashCode;
                result = (result << 5) + result ^ (Id.GetHashCode ());
                result = (result << 5) + result ^ (FirstName != null ? FirstName.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (LastName != null ? LastName.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (NamedTupleCommon.StructuralGetHashCode (Aliases));
                result = (result << 5) + result ^ (InvoiceAddress != null ? InvoiceAddress.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (DeliveryAddress != null ? DeliveryAddress.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                return result;
            }

        }
        #endregion
    }


    sealed partial class Address : IEquatable<Address>, INamedTuple
    {


        public long   Id       { get; set; }
        public string CareOf   { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City     { get; set; }
        public string Zip      { get; set; }
        public string County   { get; set; }
        public string Country  { get; set; }

        #region Generated code

        public void ToString (StringBuilder sb, int indent)
        {
            sb.Append (' ', indent);
            var innerIndent = indent + 4;
            sb.AppendLine ("{");

            sb.Append (' ', innerIndent);
            sb.Append ("!Type    = ");
            sb.AppendLine (GetType ().Name);

            sb.Append (' ', innerIndent);
            sb.Append ("Id       = ");
            NamedTupleCommon.AppendValueLine (sb, Id, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("CareOf   = ");
            NamedTupleCommon.AppendStringLine (sb, CareOf, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("Address1 = ");
            NamedTupleCommon.AppendStringLine (sb, Address1, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("Address2 = ");
            NamedTupleCommon.AppendStringLine (sb, Address2, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("Address3 = ");
            NamedTupleCommon.AppendStringLine (sb, Address3, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("Address4 = ");
            NamedTupleCommon.AppendStringLine (sb, Address4, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("City     = ");
            NamedTupleCommon.AppendStringLine (sb, City, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("Zip      = ");
            NamedTupleCommon.AppendStringLine (sb, Zip, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("County   = ");
            NamedTupleCommon.AppendStringLine (sb, County, innerIndent);
            sb.Append (' ', innerIndent);
            sb.Append ("Country  = ");
            NamedTupleCommon.AppendStringLine (sb, Country, innerIndent);
            sb.Append (' ', indent);
            sb.AppendLine ("}");
        }

        public override string ToString ()
        {
            var sb = new StringBuilder ();

            ToString (sb, 0);

            return sb.ToString ();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }

        public bool Equals (Address other)
        {
            if (other == null)
            {
                return false;
            }

            var result = 
                    (Id.Equals (other.Id))
                &&  ((CareOf ?? "").Equals (other.CareOf ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((Address1 ?? "").Equals (other.Address1 ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((Address2 ?? "").Equals (other.Address2 ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((Address3 ?? "").Equals (other.Address3 ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((Address4 ?? "").Equals (other.Address4 ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((City ?? "").Equals (other.City ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((Zip ?? "").Equals (other.Zip ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((County ?? "").Equals (other.County ?? "", NamedTupleCommon.DefaultStringComparison))
                &&  ((Country ?? "").Equals (other.Country ?? "", NamedTupleCommon.DefaultStringComparison))
                ;

            return result;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = NamedTupleCommon.DefaultHashCode;
                result = (result << 5) + result ^ (Id.GetHashCode ());
                result = (result << 5) + result ^ (CareOf != null ? CareOf.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (Address1 != null ? Address1.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (Address2 != null ? Address2.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (Address3 != null ? Address3.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (Address4 != null ? Address4.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (City != null ? City.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (Zip != null ? Zip.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (County != null ? County.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                result = (result << 5) + result ^ (Country != null ? Country.GetHashCode () : NamedTupleCommon.DefaultHashCode);
                return result;
            }

        }
        #endregion
    }


    sealed partial class Session : IEquatable<Session>, INamedTuple
    {


        public long   Id       { get; set; }
        public string ClientIp { get; set; }

        #region Generated code

        public void ToString (StringBuilder sb, int indent)
        {
            sb.Append (' ', indent);
            sb.Append (base.ToString ());
        }

        public override string ToString ()
        {
            var sb = new StringBuilder ();

            ToString (sb, 0);

            return sb.ToString ();
        }

        public bool Equals (Session other)
        {
            return Equals (other as object);
        }
        #endregion
    }

}

