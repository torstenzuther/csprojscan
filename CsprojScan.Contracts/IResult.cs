using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    /// <summary>
    /// Interface for a result
    /// </summary>
    public interface IResult
    {

        /// <summary>
        /// Name of the result
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Error message if an error occurred
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// The result rows
        /// </summary>
        IEnumerable<IResultRow> Rows { get; }

    }
}
