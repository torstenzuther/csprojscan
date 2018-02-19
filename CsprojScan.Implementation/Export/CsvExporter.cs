using CsprojScan.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsprojScan.Implementation.Export
{
    public class CsvExporter : IExporter
    {
        private readonly CsvExporterSettings settings;
        private readonly IExceptionHandler exceptionHandler;

        public CsvExporter(CsvExporterSettings settings, IExceptionHandler exceptionHandler)
        {
            this.settings = settings;
            this.exceptionHandler = exceptionHandler;
        }

        public void Export(IEnumerable<IResult> results)
        {
            try
            {
                var csv = String.Empty;

                if (results != null)
                {

                    var columns = new HashSet<string>(results
                        .Where(r => r.Rows != null)
                        .SelectMany(e => e.Rows)
                        .SelectMany(r => r.KeyValuePairs)
                        .Select(r => r.Item1)
                        .OrderBy(k => k));

                    var systemColumns =
                        new[] { settings.NameColumn, settings.ErrorMessageColumn };

                    var allColumns =
                            systemColumns
                            .Concat(columns)
                            .ToList();

                    var columnIndexDict = new Dictionary<string, int>();
                    var i = 0;
                    foreach (var column in columns)
                    {
                        columnIndexDict.Add(column, i++);
                    }

                    var matrix = new List<string[]>
                    {
                        allColumns.ToArray()
                    };

                    foreach (var extract in results)
                    {
                        foreach (var row in extract.Rows)
                        {
                            var array = new string[allColumns.Count];
                            matrix.Add(array);
                            foreach (var kvp in row.KeyValuePairs)
                            {
                                array[columnIndexDict[kvp.Item1] + systemColumns.Length] = kvp.Item2;
                                array[0] = extract.Name;
                                array[1] = extract.ErrorMessage;
                            }
                        }
                    }

                    csv = String.Join(settings.Newline,
                        matrix.Select(rows => String.Join(settings.ColumnSeparator, rows)));
                }
                File.WriteAllText(settings.File, csv);
            }
            catch (System.Exception e)
            {
                this.exceptionHandler.HandleException(e);
            }

        }
    }
}
