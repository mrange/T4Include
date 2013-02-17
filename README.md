T4Include
=========

T4Include is a library of small and useful functions compatible intended to be 
include as source code (as opposed to be referenced as an assembly which is 
the standard way of sharing code in .NET).

In order to help getting started T4Include can be installed using nuget package: T4Include

The nuget package contains:

  * IncludeHeader.ttinclude    - Shared functionality
  * IncludeLocalFile.ttinclude - Includes source files located on the local harddrive
  * IncludeWebFile.ttinclude   - Includes source files located on the web
  * IncludeProject.ttinclude   - Includes source files located in another C# project
  * Include_T4Include.tt       - Example on how to reference the source

Example on how to reference dapper:
```code
<#
    Namespace = "InternalizedDapper";
    Includes = new []
        {
            Include (@"SamSaffron/dapper-dot-net/master/Dapper/SqlMapper.cs"),
        };
#>

<#@ include file="..\..\..\T4\IncludeWebFile.ttinclude" #>
```

Why include source code?
========================

Is including source code better than referencing an assembly?

In my humble opinion sharing code by assemblies have some drawbacks that 
occassionaly makes assemblies feel clunky.

  * An assembly is a visible dependency
    * Visible dependencies causes headaches because we can get version conflicts in case of large applications with many dependencies. GAC is intended to solve this but requires administrator credentials.
    * Included source code is an invisible dependency creating no versions conflicts.
  * We can't cherry-pick functionality from an assembly
    * If an assembly contains 1% of functionality I find useful then I still have to ship the 99% non-useful functionality and the hosting executable have to spend time loading it.
    * Included source code allows cherry-picking of functionality from a library such as T4Include
  * An assembly requires a certain runtime
    * When referencing a .NET4.5 assembly my application has to be .NET4.5. Sometimes I have hard restrictions on .NET2.0 and then I can't use the function even though I know that the function in question is compatible with .NET2.0.
    * Included source code can be made to target multiple platforms such as; .NET4.5, .NET2.0, SilverLight, Windows Store and so on

Including source doesn't replace referencing an assembly but for sharing code that should be easy to share (ie utility functions, collections, extension methods and so on) including source code is a great alternative to reference an assembly.

