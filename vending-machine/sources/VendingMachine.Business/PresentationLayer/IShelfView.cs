using Nagarro.VendingMachine.Models;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);

        void DisplayHeader();
    }
}