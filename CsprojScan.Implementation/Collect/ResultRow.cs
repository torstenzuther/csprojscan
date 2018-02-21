using CsprojScan.Contracts;
using System;
using System.Collections.Generic;

namespace CsprojScan.Implementation.Collect
{
    /// <summary>
    /// Default implementation of a result row
    /// </summary>
    public class ResultRow : IResultRow
    {

        /// <summary>
        /// Creates a result row
        /// </summary>
        /// <param name="kvps">the key-value-pairs to be in the row</param>
        public ResultRow(IEnumerable<Tuple<string, string>> kvps)
        {
            if (kvps == null)
            {
                KeyValuePairs = new List<Tuple<string, string>>();
            }
            else
            {
                KeyValuePairs = kvps;
            }
            
        }

        /// <summary>
        /// All key value pairs containing tuples of keys = item1 and values = item2
        /// </summary>
        public IEnumerable<Tuple<string, string>> KeyValuePairs { get; }


    }
}
