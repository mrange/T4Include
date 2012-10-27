T4Include
=========

T4Include is a library of small and useful functions compatible intended
to be referenced by source (as opposed to referenced by binary as is the 
standard).

In order to help reference by source three T4 files are provided in a nuget
package:

   * IncludeHeader.ttinclude - Shared functionality
   * IncludeLocalFile.ttinclude - References source files located on the local harddrive
   * IncludeWebFile.ttinclude - References source files located on the web

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

    