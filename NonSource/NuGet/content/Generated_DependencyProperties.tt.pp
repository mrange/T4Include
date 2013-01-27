<#
    // Note that the generating code contains extension points using partial methods

    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The new of the class that is inheriting DependencyObject
        new ClassDefinition ("TestControl")
        {
            // A normal property
            P ("bool"   ,   "IsValid"           ),
            // An attached property
            P ("string" ,   "AttachedValue"     , flags:PropertyFlags.IsAttached    )
        },
    };

#>

<#@ include file="$(SolutionDir)\T4\DependencyProperties.ttinclude" #>


