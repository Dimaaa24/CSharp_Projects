using Nagarro.VendingMachine.DataAccess;
using VendingMachine.Business.Models;
using VendingMachine.Business.SerializedObjects;

namespace VendingMachine.DataAccess.Sqlite
{
    internal class EFSqliteSaleRepository : ISaleRepository
    {
        private VendingMachineContext vendingMachineContext;

        public EFSqliteSaleRepository(VendingMachineContext vendingMachineContext)
        {
            this.vendingMachineContext = vendingMachineContext ?? throw new ArgumentNullException(nameof(vendingMachineContext));
        }

        public void CreateNewSale(Sale sale)
        {
            vendingMachineContext.Add(sale);
            vendingMachineContext.SaveChanges();
        }

        public IEnumerable<Sale> GetAllInAPeriod(DateTime startDate, DateTime endDate)
        {
           return vendingMachineContext.Sales.Where(s => s.Date >= startDate && s.Date <= endDate).ToList();
        }

        public List<ProductQuantity> GetVolumeInAPeriod(DateTime startDate, DateTime endDate)
        {
            return vendingMachineContext.Sales
            .Where(s => s.Date >= startDate && s.Date <= endDate)
            .GroupBy(s => s.ProductName)
            .Select(g => new ProductQuantity(g.Key, g.Count()))
            .ToList();
        }
    }
}
