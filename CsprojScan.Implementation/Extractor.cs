using CsprojScan.Contracts;

namespace CsprojScan.Implementation
{
    public class Extractor : IExtractor
    {
        public IResult Extract(string file)
        {
            return new Result();
        }
    }
}
