using CsprojScan.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CsprojScan.Implementation.Collect
{
    /// <summary>
    /// Default implementation of a result collector
    /// </summary>
    public class ResultCollector : IResultCollector
    {
        private readonly IExtractor extractor;
        private readonly IFileCrawler fileCrawler;

        /// <summary>
        /// Creates a new result collector
        /// </summary>
        /// <param name="extractor">the extractor to be used to get result from a file</param>
        /// <param name="fileCrawler">the file crawler to be used to find files to extract from</param>
        public ResultCollector(IExtractor extractor, IFileCrawler fileCrawler)
        {
            this.extractor = extractor;
            this.fileCrawler = fileCrawler;
        }

        /// <summary>
        /// Collects all results and returns an IEnumerable of results
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IResult> CollectResults()
        {
            return fileCrawler.GetFiles()
                .Select(f => extractor.Extract(f));
        }
    }
}
