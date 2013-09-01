<#
    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // Generates extension methods for enum-like values
        E ("T4IncludeControlFlags")     ,
        // Generates extension methods for int-like values
        I ("Int64")                     ,
        // Generates extension methods for float-like values
        F ("Double")                    , 
        F ("Decimal")                   ,
        // Generates extension methods for timespan-like values
        TS("TimeSpan")                  ,
        // Generates extension methods for datetime-like values
        DT("DateTime")                  ,
    };
#>
<#@ include file="$(SolutionDir)\packages\T4IncludeTemplate.1.0.3\T4\NumericalExtensions.ttinclude" #>
