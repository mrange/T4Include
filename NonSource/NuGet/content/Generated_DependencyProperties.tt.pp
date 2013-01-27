<#
    // Note that the generating code contains extension points using partial methods

    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The new of the class that is inheriting DependencyObject
        new ClassDefinition ("T4IncludeControl")
        {
            // A normal property
            P ("bool"   ,   "IsValid"           ),
            // An attached property
            P ("string" ,   "AttachedValue"     , flags:PropertyFlags.IsAttached    )
        },
    };

#>

<#@ include file="$(SolutionDir)\packages\T4IncludeWPF.1.0.1\T4\DependencyProperties.ttinclude" #>


