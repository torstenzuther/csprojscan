using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    public interface IResultCollector
    {
        IEnumerable<IResult> CollectResults();
    }
}
