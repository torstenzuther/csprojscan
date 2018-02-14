using CsprojScan.Contracts;
using CsprojScan.Implementation.Model;
using System.Xml;
using System.Xml.Serialization;

namespace CsprojScan.Implementation.Collect
{
    public class Extractor : IExtractor
    {
        private readonly IExceptionHandler exceptionHandler;

        public Extractor(IExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }

        public IResult Extract(string file)
        {
            try
            {
                using (var xmlReader = XmlReader.Create(file))
                {
                    var serializer = new XmlSerializer(typeof(Project), new XmlRootAttribute("Project"));
                    var deserialized = (Project)serializer.Deserialize(xmlReader);
                }
                
                return new Result();
            }
            catch (System.Exception e)
            {
                this.exceptionHandler.HandleException(e);
                return new Result
                {
                    ErrorMessage = $"{e.Message}:{e.StackTrace}",
                    HasErrors = true,
                    Name = file
                };
            }
        }
    }
}
