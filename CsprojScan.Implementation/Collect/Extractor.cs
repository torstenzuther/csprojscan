using CsprojScan.Contracts;
using CsprojScan.Implementation.Extensions;
using Microsoft.Build.Construction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsprojScan.Implementation.Collect
{
    public class Extractor : IExtractor
    {
        private readonly IExceptionHandler exceptionHandler;

        public Extractor(IExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }

        public IResult Extract(string file)
        {
            try
            {
                var projectRoot = ProjectRootElement.Open(file);
                var rows = new List<KeyValuePair<string, string>>();
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
