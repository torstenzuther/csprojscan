using CsprojScan.Contracts;
using CsprojScan.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CsprojScan.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                PrintUsage();
            }
            else
            {
                System.Console.WriteLine("Starting export...");
                var serviceProvider = args.Length > 2 ? ScanMe.Now(args[0], args[1], args[2])
                    : ScanMe.Now(args[0], args[1]);

                var results = serviceProvider.GetRequiredService<IResultCollector>().CollectResults();
                serviceProvider.GetRequiredService<IExporter>().Export(results);

                System.Console.WriteLine("Export finished.");
            }

            System.Console.ReadLine();
        }

        static void PrintUsage()
        {
            var usage = new[] { "Usage: CsprojScan search-path export-file [search-pattern]",
                "* search-path is the start search path",
                "* export-file is the file name to export to (will be overwritten)",
                "* optional search pattern (defaults to *.csproj)"};

            foreach (var line in usage)
                System.Console.WriteLine(line);

        }
    }
}
