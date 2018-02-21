namespace CsprojScan.Implementation.Export
{
    /// <summary>
    /// Settings for the CSV exporter
    /// </summary>
    public class CsvExporterSettings
    {
        /// <summary>
        /// the file to export to
        /// </summary>
        public string File { get; set; }
        
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

        /// <summary>
        /// Controls if pivotgrid should be also exported
        /// </summary>
        public bool ExportPivotGrid { get; set; }

    }
}
