using CsprojScan.Contracts;
using CsprojScan.Implementation.Collect;
using CsprojScan.Implementation.Exception;
using CsprojScan.Implementation.Export;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CsprojScan.DependencyInjection
{
    /// <summary>
    /// Service collection extensions for registering CsprojScan dependencies
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Registers CsprojScan dependencies to service collection
        /// </summary>
        /// <param name="serviceCollection">the service collection to use</param>
        /// <param name="basePaths">all paths to look for csproj files</param>
        /// <param name="exportFilename">the file to export the results to</param>
        /// <param name="exportPivotgrid">true, if html pivot grid should be created or false, otherwise</param>
        /// <param name="searchPattern">an optional search pattern for files (default is *.csproj)</param>
        /// <returns></returns>
        public static IServiceCollection UseCsprojScan(this IServiceCollection serviceCollection,
            IEnumerable<string> basePaths, string exportFilename, bool exportPivotgrid = true, string searchPattern = "*.csproj")
        {
            return serviceCollection
                .AddTransient<IExceptionHandler, ExceptionHandler>()
                .AddTransient<IExporter, CsvExporter>()
                .AddTransient(sp => new CsvExporterSettings {
                                    ColumnSeparator = ",",
                                    ErrorMessageColumn = "Error message",
                                    NameColumn = "Csproj",
                                    File = exportFilename,
                                    Newline = Environment.NewLine,
                                    ExportPivotGrid = exportPivotgrid
                            })
                .AddTransient(sp => new FileCrawlerSettings {
                                    BasePaths = basePaths,
                                    SearchPattern = searchPattern
                                })
                .AddTransient<IExtractor, Extractor>()
                .AddTransient<IFileCrawler, FileCrawler>()
                .AddTransient<IResult, Result>()
                .AddTransient<IResultCollector, ResultCollector>();
        }

    }
}
