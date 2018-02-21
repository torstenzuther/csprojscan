using CsprojScan.Contracts;
using CsprojScan.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;

namespace CsprojScan.Console
{
    /// <summary>
    /// Main program. See PrintUsage
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2 || args.Any(s => string.IsNullOrEmpty(s)))
            {
                PrintUsage();
            }
            else
            {
                System.Console.WriteLine("Starting...");
                var searchPaths = args[0].Split(';');
                var exportFile = args[1];
                var serviceProvider = args.Length > 2 ? ScanMe.Now(searchPaths, exportFile, args[2])
                    : ScanMe.Now(searchPaths, exportFile);

                var results = serviceProvider.GetRequiredService<IResultCollector>().CollectResults();
                serviceProvider.GetRequiredService<IExporter>().Export(results);

                System.Console.WriteLine("Finished.");
                Process.Start("pivotgrid.html");
            }

            System.Console.WriteLine("Press enter to close.");
            System.Console.ReadLine();
        }

        static void PrintUsage()
        {
            var usage = new[] { "Usage: CsprojScan <search-paths> <export-file> [search-pattern]",
                "* <search-paths> is the start search path. Multiple paths can be separated by ; (no whitespaces allowed)",
                "* export-file is the file name to export to (will be overwritten)",
                "* optional search pattern (defaults to *.csproj)"};

            foreach (var line in usage)
                System.Console.WriteLine(line);

        }
    }
}
