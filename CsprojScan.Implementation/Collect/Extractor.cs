using CsprojScan.Contracts;
using Microsoft.Build.Construction;
using System;
using System.Collections.Generic;

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
                var projectRoot = Microsoft.Build.Construction.ProjectRootElement.Open(file);
                var rows = new List<KeyValuePair<string, string>>();
                var result = new Result
                {
                    Name = file,
                    Rows = rows
                };
                foreach (var child in projectRoot.AllChildren)
                {
                    var rowsToAdd = GetRows(child);
                    rows.AddRange(rowsToAdd);
                }
                return result;
            }
            catch (System.Exception e)
            {
                this.exceptionHandler.HandleException(e);
                return new Result
                {
                    ErrorMessage = $"{e.Message}:{e.StackTrace}",
                    HasErrors = true,
                    Name = file
                };
            }
        }

        private IEnumerable<KeyValuePair<string, string>> GetRows(ProjectElement child)
        {
            var result = new List<KeyValuePair<string, string>>();
            if (child is ProjectPropertyElement projectPropertyElement)
            {
                return GetRows(projectPropertyElement);
            }
            return result;
        }

        private IEnumerable<KeyValuePair<string, string>> GetRows(ProjectPropertyElement projectPropertyElement)
        {
            return new []
            {
                new KeyValuePair<string, string>(projectPropertyElement.Name, projectPropertyElement.Value)
            };
        }
    }
}
