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
    sealed class IsIdentityAttribute : System.Attribute
    {
    }

    sealed partial class CUS_Customer
    {
        [IsIdentity]
        public System.Int64                             CUS_ID                                   { get; set; }
        public System.String                            CUS_FirstName                            { get; set; }
        public System.String                            CUS_LastName                             { get; set; }
        public System.DateTime?                         CUS_BirthDate                            { get; set; }
        public System.DateTime                          CUS_Created                              { get; set; }
    }
    sealed partial class CAD_CustomerAddress
    {
        [IsIdentity]
        public System.Int64                             CAD_ID                                   { get; set; }
        public System.Int64                             CAD_CUS_ID                               { get; set; }
        public System.String                            CAD_AddressLine1                         { get; set; }
        public System.String                            CAD_AddressLine2                         { get; set; }
        public System.String                            CAD_AddressLine3                         { get; set; }
        public System.String                            CAD_AddressLine4                         { get; set; }
        public System.String                            CAD_AddressLine5                         { get; set; }
        public System.String                            CAD_Zip                                  { get; set; }
        public System.String                            CAD_City                                 { get; set; }
        public System.String                            CAD_County                               { get; set; }
        public System.String                            CAD_Country                              { get; set; }
        public System.DateTime?                         CAD_Created                              { get; set; }
    }

}
