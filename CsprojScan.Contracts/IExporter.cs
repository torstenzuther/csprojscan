using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    public interface IExporter
    {
        void Export(IEnumerable<IResult> results);
    }
}
