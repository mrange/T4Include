<#
    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The name of a class
        new ClassDefinition ("T4IncludeControl")
        {
            // The name of the command
            C ("CreateUser")    , 
        },
    };

#>

<#@ include file="$(SolutionDir)\packages\T4IncludeWPF.1.0.1\T4\RoutedCommands.ttinclude" #>


