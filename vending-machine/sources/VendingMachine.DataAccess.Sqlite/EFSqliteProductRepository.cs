using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Models;

namespace VendingMachine.DataAccess.Sqlite
{
    internal class EFSqliteProductRepository : IProductRepository
    {
        private VendingMachineContext vendingMachineContext;

        public EFSqliteProductRepository(VendingMachineContext vendingMachineContext)
        {
            this.vendingMachineContext = vendingMachineContext ?? throw new ArgumentNullException(nameof(vendingMachineContext));
        }
        public void DecrementStock(int id)
        {
            var product = vendingMachineContext.Products.Find(id);

            if(product != null)
            {
                product.Quantity--;
            }

            vendingMachineContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return vendingMachineContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return vendingMachineContext.Products.Find(id);
        }
    }
}
