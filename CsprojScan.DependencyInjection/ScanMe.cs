using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CsprojScan.DependencyInjection
{
    /// <summary>
    /// Static class for building a service provider which contains all necessary Csprojscan dependencies
    /// </summary>
    public static class ScanMe
    {
        /// <summary>
        /// Returns a service provider containing all CsprojScan dependencies
        /// </summary>
        /// <param name="basePaths">the paths to look for files</param>
        /// <param name="searchPattern">an optional search pattern for files (default is *.csproj)</param>
        /// <returns>a service provider containing all CsprojScan dependencies</returns>
        public static IServiceProvider Now(IEnumerable<string> basePaths, string searchPattern = "*.csproj")
        {
            var serviceCollection = new ServiceCollection()
                                    .UseCsprojScan(basePaths, searchPattern);
            return serviceCollection.BuildServiceProvider();
        }
    }
}
