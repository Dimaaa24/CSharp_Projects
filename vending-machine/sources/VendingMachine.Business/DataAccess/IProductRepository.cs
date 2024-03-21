using Nagarro.VendingMachine.Models;

namespace Nagarro.VendingMachine.DataAccess
{
    internal interface IProductRepository
    {
        void DecrementStock(int id);

        IEnumerable<Product> GetAll();

        Product GetById(int id);
    }
}