using Microsoft.AspNetCore.Mvc;
using Nagarro.VendingMachine.Models;
using VendingMachine.Business.Models;
using VendingMachine.DataAccess.Sqlite;

namespace VendingMachineAPI.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly VendingMachineContext vendingMachineContext;

        public SaleController(VendingMachineContext vendingMachineContext)
        {
            this.vendingMachineContext = vendingMachineContext;
        }

        /// <summary>
        /// </summary>
        /// <param name="startDate">Date format: mm-dd-yyyy. Example : 10-24-2002</param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetAll(DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate == null || endDate == null)
            {
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }

            return Ok(vendingMachineContext.Sales.Where(s => s.Date >= startDate && s.Date <= endDate).ToList());
        }

        /// <summary>
        /// </summary>
        /// <param name="startDate">Date format: mm-dd-yyyy. Example : 10-24-2002</param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteSales(DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate == null || endDate == null)
            {
                return BadRequest();
            }

            foreach (var sale in vendingMachineContext.Sales) 
            {
                if(sale.Date >= startDate && sale.Date <= endDate)
                    vendingMachineContext.Sales.Remove(sale);
            }

            await vendingMachineContext.SaveChangesAsync();
            return Ok();
        }
    }
}
