using CsprojScan.Contracts;
using System.Collections.Generic;

namespace CsprojScan.Implementation.Collect
{
    public class Result : IResult
    {
        public Result()
        {
            Rows = new List<KeyValuePair<string, string>>();
        }

        public string Name { get; set; }

        public bool HasErrors { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Rows { get; set; }
    }
}
