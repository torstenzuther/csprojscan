using CsprojScan.Contracts;
using System.Collections.Generic;

namespace CsprojScan.Implementation.Collect
{
    /// <summary>
    /// Default implementation of a result
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        /// Creates a new result
        /// </summary>
        public Result()
        {
            Rows = new List<IResultRow>();
        }

        /// <summary>
        /// Name of the result
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Error message if an error occurred
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// The result rows
        /// </summary>
        public IEnumerable<IResultRow> Rows { get; set; }
    }
}
