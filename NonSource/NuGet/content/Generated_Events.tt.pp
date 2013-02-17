<#
    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The name of a class
        new ClassDefinition ("T4IncludeControl")
        {
            // The name of the event
            E ("Activate")      , 
            E ("Deactivate")    , 
        },
    };

#>
<#@ include file="$(SolutionDir)\packages\T4IncludeWPF.1.0.3\T4\RoutedEvents.ttinclude" #>
