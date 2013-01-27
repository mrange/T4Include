<#
    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The name of a class
        new ClassDefinition ("TestControl")
        {
            // The name of the command
            C ("CreateUser")    , 
        },
    };

#>

<#@ include file="$(SolutionDir)\T4\RoutedCommands.ttinclude" #>


