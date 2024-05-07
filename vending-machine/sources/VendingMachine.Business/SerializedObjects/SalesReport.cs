using Newtonsoft.Json;
using System.Xml.Serialization;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.SerializedObjects
{
    [Serializable]
    [XmlRoot("SalesReport")]
    public class SalesReport
    {
        [XmlElement("Sale")]
        [JsonProperty("Sales")]
        public List<Sale> stock;

        public SalesReport()
        {
            stock = new List<Sale>();
        }

        public SalesReport(IEnumerable<Sale> sales)
        {
            stock = sales.ToList();
        }
    }
}
