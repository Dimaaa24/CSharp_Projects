using System.Xml.Serialization;

namespace VendingMachine.Business.SerializedObjects
{
    [Serializable]
    [XmlRoot("Product")]
    public class ProductQuantity
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }

        public ProductQuantity() { }

        public ProductQuantity(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
