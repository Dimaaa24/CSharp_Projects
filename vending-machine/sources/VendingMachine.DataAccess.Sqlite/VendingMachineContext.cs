using Microsoft.EntityFrameworkCore;
using Nagarro.VendingMachine.Models;
using VendingMachine.Business.Models;

namespace VendingMachine.DataAccess.Sqlite
{
    public class VendingMachineContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public VendingMachineContext(DbContextOptions<VendingMachineContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasKey(s => new { s.ProductName, s.Date });
        }
    }
}
