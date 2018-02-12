using Microsoft.Extensions.DependencyInjection;
using System;

namespace CsprojScan.DependencyInjection
{
    public static class ScanMe
    {
        public static IServiceProvider Now(string basePath, string exportFilename, string searchPattern = "*.csproj")
        {
            var serviceCollection = new ServiceCollection()
                                    .UseCsprojScan(basePath, exportFilename, searchPattern);
            return serviceCollection.BuildServiceProvider();
        }
    }
}
