using VendingMachine.Business.Models;
using VendingMachine.Business.SerializedObjects;

namespace Nagarro.VendingMachine.DataAccess
{
    internal interface ISaleRepository
    {
        void CreateNewSale(Sale sale);
        IEnumerable<Sale> GetAllInAPeriod(DateTime startDate, DateTime endDate);
        List<ProductQuantity> GetVolumeInAPeriod(DateTime startDate, DateTime endDate);
    }
}