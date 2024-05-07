using Nagarro.VendingMachine.Models;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace VendingMachine.Business.SerializedObjects
{
    [XmlRoot("StockReport")]
    public class StockReport
    {
        [XmlElement("Product")]
        [JsonProperty("Stock")]
        public List<ProductQuantity> Stock { get; set; }

        public StockReport() 
        {
            Stock = new List<ProductQuantity> ();
        }

        public StockReport(IEnumerable<Product> products)
        {
            Stock = new List<ProductQuantity>();

            foreach (Product product in products)
            {
                Stock.Add(new ProductQuantity { Name = product.Name, Quantity = product.Quantity});
            }
        }
    }
}
