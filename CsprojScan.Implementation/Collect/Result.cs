using CsprojScan.Contracts;
using System.Collections.Generic;

namespace CsprojScan.Implementation.Collect
{
    public class Result : IResult
    {
        public Result()
        {
            Rows = new List<IResultRow>();
        }

        public string Name { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<IResultRow> Rows { get; set; }
    }
}
