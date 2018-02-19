using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    public interface IResult
    {

        string Name { get; }

        string ErrorMessage { get; }

        IEnumerable<IResultRow> Rows { get; }

    }
}
