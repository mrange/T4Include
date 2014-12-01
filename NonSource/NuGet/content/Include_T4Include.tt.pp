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
            // Include (@"StackExchange/dapper-dot-net/master/Dapper%20NET40/SqlMapper.cs"),
        };
#>

<#@ include file="$(SolutionDir)\packages\T4Include.1.1.4\T4\IncludeWebFile.ttinclude" #>
