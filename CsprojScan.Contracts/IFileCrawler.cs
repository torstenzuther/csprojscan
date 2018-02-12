using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    /// <summary>
    /// Interface for a file crawler
    /// </summary>
    public interface IFileCrawler
    {
        /// <summary>
        /// Returns all found files (full paths)
        /// </summary>
        /// <returns>All found files (full paths)</returns>
        IEnumerable<string> GetFiles();
    }
}