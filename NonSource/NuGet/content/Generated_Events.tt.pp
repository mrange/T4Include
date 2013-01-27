<#
    // The namespace the generated code is placed in
    Namespace   = "$rootnamespace$"         ;   

    Model = new []
    {
        // The name of a class
        new ClassDefinition ("TestControl")
        {
            // The name of the event
            E ("Activate")      , 
            E ("Deactivate")    , 
        },
        // The name of a static class
        new ClassDefinition ("OtherTest", isStatic:true)
        {
            // The name of the event
            E ("OtherEvent")  , 
        },
    };

#>
<#@ include file="$(SolutionDir)\T4\RoutedEvents.ttinclude" #>
