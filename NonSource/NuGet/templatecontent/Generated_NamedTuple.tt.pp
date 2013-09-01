<#
    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The name of the tuple
        new TupleDefinition ("Customer")
        {
            // V: Defines a value type member (ie struct)
            V ("long"       , "Id"              ),
            // R: Defines a reference type member (ie class)
            R ("string"     , "FirstName"       ),
            R ("string"     , "LastName"        ),
            // A: Defines an array type member
            A ("string"     , "Aliases"         ),
            // Uses the Address tuple defined below
            R ("Address"    , "InvoiceAddress"  ),
            R ("Address"    , "DeliveryAddress" ),
        }, 
        new TupleDefinition ("Address")
        {
            V ("long"       , "Id"          ),
            R ("string"     , "CareOf"      ),
            R ("string"     , "Address1"    ),
            R ("string"     , "Address2"    ),
            R ("string"     , "Address3"    ),
            R ("string"     , "Address4"    ),
            R ("string"     , "City"        ),
            R ("string"     , "Zip"         ),
            R ("string"     , "County"      ),
            R ("string"     , "Country"     ),
        }, 
        // The name of the tuple, this tuple doesn't support structural equality or human readable tostring
        new TupleDefinition ("Session", structuralTuple:false, generateToString:false)
        {
            V ("long"       , "Id"          ),
            R ("string"     , "ClientIp"    ),
        }, 
    };
#>
<#@ include file="$(SolutionDir)\packages\T4IncludeTemplate.1.0.3\T4\NamedTuple.ttinclude" #>
