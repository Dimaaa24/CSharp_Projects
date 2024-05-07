using Newtonsoft.Json;
using System.Xml.Serialization;

namespace VendingMachine.Business.SerializedObjects
{
    [Serializable]
    [XmlRoot("VolumeReport")]
    public class VolumeReport
    {
        [XmlElement("StartTime")]
        [JsonProperty("StartTime")]
        public DateTime startDate;
        [XmlElement("EndTime")]
        [JsonProperty("EndTime")]
        public DateTime endDate;
        [JsonProperty("Products")]
        [XmlArray("Sales")]
        [XmlArrayItem("Product")]
        public List<ProductQuantity> products;

        public VolumeReport()
        {
            products = new List<ProductQuantity>();
        }

        public VolumeReport(DateTime startDate, DateTime endDate, List<ProductQuantity> products)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.products = products;
        }
    }
}
