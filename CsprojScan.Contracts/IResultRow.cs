using System;
using System.Collections.Generic;

namespace CsprojScan.Contracts
{
    public interface IResultRow
    {
        
        IEnumerable<Tuple<string, string>> KeyValuePairs { get; }

    }
}