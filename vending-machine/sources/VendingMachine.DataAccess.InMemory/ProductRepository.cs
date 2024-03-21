using Nagarro.VendingMachine.Models;

namespace Nagarro.VendingMachine.DataAccess.InMemory
{
    internal sealed class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Soda", Price=20, Quantity=5 },
            new Product { Id = 2, Name = "Cookie", Price=5, Quantity=10 },
            new Product { Id = 3, Name = "Coffee", Price=15, Quantity=9 }
        };

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void DecrementStock(int id)
        {
            GetById(id).Quantity--;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}