<#
    // Whenever this file is saved the files in the Includes section is downloaded
    // from GitHub (you can download from other websources by changing rootpath)
    RootPath    = @"https://raw.github.com/";
    Namespace   = "$rootnamespace$"         ;   // The downloaded content is wrapped in this namespace
    Includes    = new []
        {
            // Include the basic extension from T4Include
            Include (@"mrange/T4Include/master/Extensions/BasicExtensions.cs"),

            // Uncomment below to include dapper
            // Include (@"SamSaffron/dapper-dot-net/master/Dapper/SqlMapper.cs"),
        };
#>

<#@ include file="$(SolutionDir)\packages\T4Include.1.0.5\T4\IncludeWebFile.ttinclude" #>