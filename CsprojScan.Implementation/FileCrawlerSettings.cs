namespace CsprojScan.Implementation
{
    /// <summary>
    /// Contains settings for a file crawler
    /// </summary>
    public class FileCrawlerSettings
    {
        /// <summary>
        /// The base path to start crawling
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// The search pattern to search for
        /// </summary>
        public string SearchPattern { get; set; }

    }
}