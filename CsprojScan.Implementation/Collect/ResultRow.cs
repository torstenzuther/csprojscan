using CsprojScan.Contracts;
using System;
using System.Collections.Generic;

namespace CsprojScan.Implementation.Collect
{
    public class ResultRow : IResultRow
    {

        public ResultRow(IEnumerable<Tuple<string, string>> kvps)
        {
            if (kvps == null)
            {
                KeyValuePairs = new List<Tuple<string, string>>();
            }
            else
            {
                KeyValuePairs = kvps;
            }
            
        }

        public IEnumerable<Tuple<string, string>> KeyValuePairs { get; }


    }
}
