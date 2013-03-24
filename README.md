T4Include
=========

T4Include is a library of small and useful functions intended to be 
included as source code in .NET (as opposed to referencing them as an assembly which is 
the standard way of sharing code in .NET).

To make it easier to get started T4Include can be installed using nuget: <http://nuget.org/packages/T4Include/>

The nuget package contains:

```
  * IncludeHeader.ttinclude    - Shared functionality
  * IncludeLocalFile.ttinclude - Includes source files located on the local harddrive
  * IncludeWebFile.ttinclude   - Includes source files located on the web
  * IncludeProject.ttinclude   - Includes source files located in another C# project
  * Include_T4Include.tt       - Example on how to reference the source
```

Example on how to reference dapper:
```code
<#
    Namespace = "InternalizedDapper";
    Includes = new []
        {
            Include (@"SamSaffron/dapper-dot-net/master/Dapper/SqlMapper.cs"),
        };
#>

<#@ include file="$(SolutionDir)\packages\T4Include.1.1.2\T4\IncludeWebFile.ttinclude" #>
```

Why include source code?
========================

Is including source code better than referencing an assembly?

In my humble opinion sharing code by assemblies has some drawbacks that 
occasionally makes assemblies feel clunky.

  * An assembly is a visible dependency:
    * Visible dependencies cause headaches because we can get version conflicts in large applications with many dependencies. GAC is intended to solve this but requires administrator credentials.
    * Included source code is an invisible dependency creating no versions conflicts.
  * We can't cherry-pick functionality from an assembly:
    * If an assembly contains 1% of functionality I find useful then I still have to ship the 99% non-useful functionality and the hosting executable has to spend time loading it.
    * Including source code allows cherry-picking of functionality from a library such as T4Include
  * An assembly requires a certain runtime:
    * When referencing a .NET4.5 assembly my application has to be using .NET4.5. Sometimes I have hard restrictions on .NET2.0 and then I can't use the function even though I know that the function in question is compatible with .NET2.0.
    * Included source code can be made to target multiple platforms such as; .NET4.5, .NET2.0, SilverLight, Windows Store and so on

Including source doesn't replace referencing an assembly but for sharing code that should be easy to share (i.e. utility functions, collections, extension methods and so on) including source code is a great alternative to referencing an assembly.

History of T4Include
====================

After working in a couple of large organizations with the vision of creating product lines I have been subjected to some of the pains of trying to incorporate product line assets into a single hosting process. This is often painful, sometimes impossible.

This is a difficult problem and in order to succeed, the whole product line has to be constructed from the start with an eye on how their assets will be integrated with other assets in a single hosting process. At the start of a project, this is often overlooked or forgotten and the problem is first realized when the first application team tries to integrate disparate assets.

After a few years of projects of this type, I started thinking about C++ and boost. Boost has two classes of functionality:
 * One part which requires a precompiled library. This is difficult to integrate:
  * Needs correct compiler
  * Needs correct architecture
  * Needs correct build
  * Creates visible dependencies (with all its woes)
  * Has to be integrated in the existing build process which slows the often already slow process
 * Another part which only requires the referencing code to #include the file
  * Often template classes because in C++ template classes can't be put in a precompiled library
  * Just works

I wanted something like C++'s #include in C#, hence T4Include. But T4Include goes further:
 * It can include from web resources
 * It can include whole projects
 * Including is done when the T4 file output is rebuilt, not necessarily during build 
  * Saves compile time
 * Included code is version controlled in the target project
  * Simplifies branching
  * Simplifies change management
  * Robust

