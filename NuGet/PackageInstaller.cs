// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// If you cannot locate the  Microsoft Public License, please send an email to 
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------

// ### INCLUDE: ../Common/ConsoleLog.cs


namespace Source.NuGet
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;                                      
    using System.Reflection;
    using Common;

    static partial class PackageInstaller
    {
        const string NuGetUri                   = @"http://nuget.org/nuget.exe";

        public static bool InstallPackages (string[] arguments)
        {
            try
            {
                Log.HighLight ("Installing nuget packages");
        
                var executingPath       = Assembly.GetExecutingAssembly ().Location;
                var appDirectory        = AppDomain.CurrentDomain.BaseDirectory;
                var solutionDirectory   = Path.GetFullPath (Path.Combine (appDirectory, @"..\..\.."));
                var packagesDirectory   = Path.GetFullPath (Path.Combine (solutionDirectory, @"packages"));
                var flagPath            = Path.Combine (packagesDirectory, "T4Include.NuGet.PackageInstaller.flag");
                var nugetPath           = Path.Combine (packagesDirectory, "NUGET.EXE");
        
                var executingInfo       = new FileInfo (executingPath);
        
                var dateTime = executingInfo.LastWriteTime.Ticks;
        
                if (File.Exists (flagPath))
                {
                    var flagContent = File.ReadAllText (flagPath);
                    long flagDateTime;
                    if (
                            long.TryParse (flagContent, NumberStyles.Integer, CultureInfo.InvariantCulture, out flagDateTime)
                        &&  flagDateTime >= dateTime 
                        )
                    {
                        Log.Success ("Installing of nuget packages skipped as flag file found: {0}", flagPath);
       
                        return true;
                    }
                }
        
                if (!Directory.Exists (packagesDirectory))
                {
                    Log.HighLight ("package folder not found, creating it : {0}", packagesDirectory);
                    Directory.CreateDirectory (packagesDirectory);
                }
        
                if (!File.Exists (nugetPath))
                {
                    Log.HighLight ("NuGet.exe not found, downloading it to: {0}", nugetPath);

                    Log.Info ("Downloading binary: {0}", NuGetUri);

                    using (var wc = new WebClient ())
                    {
                        wc.DownloadFile (NuGetUri, nugetPath);
                    }
                }
        
                var packages = Directory
                    .GetDirectories (solutionDirectory)
                    .SelectMany (path => Directory.GetFiles (path, "packages.config"))
                    ;
        
                var result = true;
        
                foreach (var package in packages)
                {
                    var commandLine = string.Format (
                        CultureInfo.InvariantCulture,
                        @"install -o ""{0}"" ""{1}""",
                        packagesDirectory,
                        package
                        );
        
                    Log.HighLight ("Installing packages: {0}", package);
                    Log.Info ("  CommandLine: {0}", commandLine);
                           
                    var process = new Process
                                        {
                                            StartInfo = new ProcessStartInfo (
                                                nugetPath,
                                                commandLine)
                                            {
                                                CreateNoWindow  = true                      ,
                                                ErrorDialog     = false                     ,
                                                WindowStyle     = ProcessWindowStyle.Hidden ,
                                            },
                                        };
                            
                    process.Start ();
                    process.WaitForExit ();
        
                    var exitCode = process.ExitCode;
        
                    if (exitCode != 0)
                    {
                        result = false;
                        Log.Error ("Failed to install nuget package: {0}", exitCode);
                    }
        
                }
        
        
                if (result)
                {
                    Environment.ExitCode = 0;
                    File.WriteAllText (flagPath, dateTime.ToString (CultureInfo.InvariantCulture));
                    Log.Success ("Installing of nuget packages done");
                }
                else
                {
                    Environment.ExitCode = 101;
                    Log.Error ("Failed to install nuget packages");
                }
        
                return result;
            }
            catch (Exception exc)
            {
                Environment.ExitCode = 999;
                Log.Exception ("InstallPackages failed with: {0}", exc.Message);
                return false;
            }
        }
    }
}
