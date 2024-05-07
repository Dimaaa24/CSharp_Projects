using Microsoft.AspNetCore.Mvc;
using Nagarro.VendingMachine.Models;
using VendingMachine.DataAccess.Sqlite;

namespace VendingMachineAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly VendingMachineContext vendingMachineContext;

        public ProductController(VendingMachineContext vendingMachineContext)
        {
            this.vendingMachineContext = vendingMachineContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return Ok(vendingMachineContext.Products.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product product = vendingMachineContext.Products.Find(id);

            if(product == null) 
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{request.id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product request)
        {
            Product product = vendingMachineContext.Products.Find(request.Id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Quantity = request.Quantity;

            await vendingMachineContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            vendingMachineContext.Products.Add(product);
            await vendingMachineContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddProduct), product, new { id = product.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            foreach(var product in vendingMachineContext.Products)
            {
                if (product.Id == id)
                    vendingMachineContext.Products.Remove(product);
            }
            await vendingMachineContext.SaveChangesAsync();
            return Ok();
        }
    }
}
