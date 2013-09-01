<#
    // Note that the generating code contains extension points using partial methods

    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The name of the class that is inheriting DependencyObject
        new ClassDefinition ("T4IncludeControl")
        {
            // A normal property
            P ("bool"                   ,   "IsValid"           ),
            // A normal property referencing a type defined in the target assembly
            P ("T4IncludeControlFlags"  ,   "ControlFlags"      ),
            // An attached property
            P ("string"                 ,   "AttachedValue"     , flags:PropertyFlags.IsAttached    )
        },
    };

#>

<#@ include file="$(SolutionDir)\packages\T4IncludeTemplate.1.0.3\T4\DependencyProperties.ttinclude" #>


