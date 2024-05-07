using Newtonsoft.Json;
using System.Xml.Serialization;

namespace VendingMachine.Business.Models
{
    [Serializable]
    public sealed class Sale
    {
        [XmlElement("Name")]
        [JsonProperty("Name")]
        public string ProductName { get; set; }
        [XmlElement("Price")]
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        [XmlElement("PaymentMethod")]
        [JsonProperty("PaymentMethod")]
        public string PaymentType { get; set; }
        [XmlElement("Date")]
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
    }
}
