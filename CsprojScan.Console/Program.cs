using CsprojScan.Contracts;
using CsprojScan.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
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
            if (args.Length < 1 || args.Any(s => string.IsNullOrEmpty(s)))
            {
                PrintUsage();
            }
            else
            {
                System.Console.WriteLine("Starting...");
                var searchPaths = args[0].Split(Path.PathSeparator);
                var serviceProvider = args.Length > 2 ? ScanMe.Now(searchPaths, args[1])
                    : ScanMe.Now(searchPaths);

                var results = serviceProvider.GetRequiredService<IResultCollector>().CollectResults();
                serviceProvider.GetRequiredService<IExporter>().Export(results);

                System.Console.WriteLine("Finished.");
            }

            System.Console.WriteLine("Press enter to close.");
            System.Console.ReadLine();
        }

        static void PrintUsage()
        {
            var usage = new[] { "Usage: CsprojScan.Console.exe <search-paths> [<search-pattern>]",
                "* <search-paths> is the start search path. Multiple paths can be separated by " + Path.PathSeparator + " (no whitespaces allowed)",
                "* optional <search-pattern> (defaults to *.csproj)"};

            foreach (var line in usage)
                System.Console.WriteLine(line);

        }
    }
}
