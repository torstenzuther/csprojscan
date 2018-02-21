using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    /// <summary>
    /// Interface for an exporter
    /// </summary>
    public interface IExporter
    {
        /// <summary>
        /// Exports results
        /// </summary>
        /// <param name="results">the results to be exported</param>
        void Export(IEnumerable<IResult> results);
    }
}
