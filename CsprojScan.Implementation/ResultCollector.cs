using CsprojScan.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CsprojScan.Implementation
{
    public class ResultCollector : IResultCollector
    {
        private readonly IExtractor extractor;
        private readonly IFileCrawler fileCrawler;

        public ResultCollector(IExtractor extractor, IFileCrawler fileCrawler)
        {
            this.extractor = extractor;
            this.fileCrawler = fileCrawler;
        }

        public IEnumerable<IResult> CollectResults()
        {
            return fileCrawler.GetFiles()
                .Select(f => extractor.Extract(f));
        }
    }
}
