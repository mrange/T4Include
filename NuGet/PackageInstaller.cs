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

// ### INCLUDE: ../Common/Log.cs

namespace Source.NuGet
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;                                      
    using System.Reflection;

    using Common;

    static partial class PackageInstaller
    {
        public static bool InstallPackages (string[] arguments)
        {
            try
            {
                Log.HighLight ("Installing nuget packages");

                const string nugetUri   = @"https://github.com/mrange/T4Include/raw/master/NonSource/NuGet/NuGet.exe.gz";
                var executingPath       = Assembly.GetExecutingAssembly ().Location;
                var appDirectory        = AppDomain.CurrentDomain.BaseDirectory;
                var solutionDirectory   = Path.GetFullPath (Path.Combine (appDirectory, @"..\..\.."));
                var packagesDirectory   = Path.GetFullPath (Path.Combine (solutionDirectory, @"packages"));
                var flagPath            = Path.Combine (packagesDirectory, "NuGetPackageInstaller.flag");
                var nugetPath           = Path.Combine (packagesDirectory, "NUGET.EXE");

                var executingInfo       = new FileInfo (executingPath);

                var time = executingInfo.CreationTime < executingInfo.LastWriteTime ? executingInfo.CreationTime : executingInfo.LastWriteTime;

                if (File.Exists (flagPath))
                {
                    Log.HighLight ("Installing of nuget packages skipped as flag found: {0}", flagPath);

                    return true;
                }

                if (!Directory.Exists (packagesDirectory))
                {
                    Log.HighLight ("package folder not found, creating it : {0}", packagesDirectory);
                    Directory.CreateDirectory (packagesDirectory);
                }

                if (!File.Exists (nugetPath))
                {
                    Log.HighLight ("NuGet.exe not found, downloading it: {0}", nugetPath);
                    var webRequest  = WebRequest.Create (nugetUri);
                    using (var webResponse = webRequest.GetResponse ())
                    using (var responseStream = webResponse.GetResponseStream ())
                    using (var gZipStream = new GZipStream (responseStream, CompressionMode.Decompress))
                    using (var fileStream = File.Create (nugetPath))
                    {
                        const int bufferSize = 4096;
                        var buffer = new byte[bufferSize];
                        var readBytes = 0;

                        while ((readBytes = gZipStream.Read (buffer, 0, bufferSize)) > 0)
                        {
                            fileStream.Write (buffer, 0, readBytes);
                        }
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

                File.WriteAllText (flagPath, time.ToString ("yyyy-MM-ddTHH:mm:ss"));

                if (result)
                {
                    Log.Success ("Installing of nuget packages done");
                }
                else
                {
                    Log.Error ("Failed to install nuget packages");
                }

                return result;
            }
            catch (Exception exc)
            {
                Log.Exception ("InstallPackages failed with: {0}", exc.Message);
                return false;
            }
            
        }
    }
}
