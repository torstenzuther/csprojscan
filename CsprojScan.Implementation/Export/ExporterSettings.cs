namespace CsprojScan.Implementation.Export
{
    /// <summary>
    /// Settings for the default exporter
    /// </summary>
    public class ExporterSettings
    {
        /// <summary>
        /// the name of the column containing the name of the result
        /// </summary>
        public string NameColumn { get; set; }

        /// <summary>
        /// the name of the column containing the error message of the result (in case of erroneous result)
        /// </summary>
        public string ErrorMessageColumn { get; set; }

        /// <summary>
        /// the newline to use as a newline separater
        /// </summary>
        public string Newline { get; set; }

        /// <summary>
        /// the column separator
        /// </summary>
        public string ColumnSeparator { get; set; }

    }
}
