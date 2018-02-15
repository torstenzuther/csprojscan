using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    public interface IResult
    {

        string Name { get; }

        string ErrorMessage { get; }

        IEnumerable<KeyValuePair<string, string>> Rows { get; }

    }
}
