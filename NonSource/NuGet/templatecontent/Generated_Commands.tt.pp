<#
    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The name of the class
        new ClassDefinition ("T4IncludeControl")
        {
            // The name of the command
            C ("CreateUser")    , 
        },
    };

#>

<#@ include file="$(SolutionDir)\packages\T4IncludeTemplate.1.0.2\T4\RoutedCommands.ttinclude" #>


