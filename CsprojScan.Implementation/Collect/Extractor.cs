using CsprojScan.Contracts;
using CsprojScan.Implementation.Extensions;
using Microsoft.Build.Construction;
using System.Collections.Generic;

namespace CsprojScan.Implementation.Collect
{
    /// <summary>
    /// Default implementation of IExtractor interface
    /// </summary>
    public class Extractor : IExtractor
    {
        private readonly IExceptionHandler exceptionHandler;

        /// <summary>
        /// Creates a new extractor
        /// </summary>
        /// <param name="exceptionHandler">the exception handler to use when an exception occurs during extraction</param>
        public Extractor(IExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }

        /// <summary>
        /// Reads file as a csproj and returns result
        /// </summary>
        /// <param name="file">the csproj file</param>
        /// <returns></returns>
        public IResult Extract(string file)
        {
            try
            {
                var projectRoot = ProjectRootElement.Open(file);
                var rows = new List<IResultRow>();
                var result = new Result
                {
                    Name = file,
                    Rows = rows
                };
                rows.AddRange(projectRoot.GetReferences());
                return result;
            }
            catch (System.Exception e)
            {
                this.exceptionHandler.HandleException(e);
                return new Result
                {
                    ErrorMessage = $"{e.Message}:{e.StackTrace}",
                    Name = file
                };
            }
        }

        
    }
}
