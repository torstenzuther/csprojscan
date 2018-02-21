using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    /// <summary>
    /// Interface for a result collector
    /// </summary>
    public interface IResultCollector
    {
        /// <summary>
        /// Collects all results and returns an IEnumerable of results
        /// </summary>
        /// <returns></returns>
        IEnumerable<IResult> CollectResults();
    }
}
