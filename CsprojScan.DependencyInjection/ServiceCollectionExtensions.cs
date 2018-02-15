using CsprojScan.Contracts;
using CsprojScan.Implementation.Collect;
using CsprojScan.Implementation.Exception;
using CsprojScan.Implementation.Export;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CsprojScan.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection UseCsprojScan(this IServiceCollection serviceCollection,
            string basePath, string exportFilename, string searchPattern = "*.csproj")
        {
            return serviceCollection
                .AddTransient<IExceptionHandler, ExceptionHandler>()
                .AddTransient<IExporter, CsvExporter>()
                .AddTransient(sp => new CsvExporterSettings {
                                    ColumnSeparator = ",",
                                    ErrorMessageColumn = "Error message",
                                    NameColumn = "ID",
                                    File = exportFilename,
                                    Newline = Environment.NewLine
                            })
                .AddTransient(sp => new FileCrawlerSettings {
                                    BasePath = basePath,
                                    SearchPattern = searchPattern
                                })
                .AddTransient<IExtractor, Extractor>()
                .AddTransient<IFileCrawler, FileCrawler>()
                .AddTransient<IResult, Result>()
                .AddTransient<IResultCollector, ResultCollector>();
        }

    }
}
