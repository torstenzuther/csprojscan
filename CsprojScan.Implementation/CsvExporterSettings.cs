namespace CsprojScan.Implementation
{
    public class CsvExporterSettings
    {
        public string File { get; set; }
        
        public string NameColumn { get; set; }

        public string HasErrorsColumn { get; set; }

        public string ErrorMessageColumn { get; set; }

        public string Newline { get; set; }

        public string ColumnSeparator { get; set; }
    }
}
