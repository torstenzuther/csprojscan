namespace CsprojScan.Contracts
{
    /// <summary>
    /// Extractor interface
    /// </summary>
    public interface IExtractor
    {
        /// <summary>
        /// Extracts a result from a file
        /// </summary>
        /// <param name="file">File from which to extract the result</param>
        /// <returns></returns>
        IResult Extract(string file);

    }
}
