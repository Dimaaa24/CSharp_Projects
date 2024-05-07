using System.Xml;
using System.Xml.Serialization;

namespace VendingMachine.Business.ReportsDocuments
{
    internal class XMLReportSerializer : IReportSerializer
    {
        public string Serialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                Encoding = System.Text.Encoding.UTF8
            };

            using (StringWriter textWriter = new StringWriter())
            using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
            {
                serializer.Serialize(xmlWriter, obj);
                return textWriter.ToString();
            }
        }
    }
}
