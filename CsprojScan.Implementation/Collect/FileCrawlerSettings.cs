using System.Collections.Generic;

namespace CsprojScan.Implementation.Collect
{
    /// <summary>
    /// Contains settings for a file crawler
    /// </summary>
    public class FileCrawlerSettings
    {
        /// <summary>
        /// The base paths to start crawling
        /// </summary>
        public IEnumerable<string> BasePaths { get; set; }

        /// <summary>
        /// The search pattern to search for
        /// </summary>
        public string SearchPattern { get; set; }

    }
}