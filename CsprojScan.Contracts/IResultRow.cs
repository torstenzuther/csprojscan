using System;
using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    /// <summary>
    /// A data row for a result
    /// </summary>
    public interface IResultRow
    {
        /// <summary>
        /// All key value pairs containing tuples of keys = item1 and values = item2
        /// </summary>
        IEnumerable<Tuple<string, string>> KeyValuePairs { get; }

    }
}