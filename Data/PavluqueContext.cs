using Microsoft.EntityFrameworkCore;
using PavluqueOrderGenerator.Model;

namespace PavluqueOrderGenerator
{
    public class PavluqueContext : DbContext
    {
        public PavluqueContext(DbContextOptions<PavluqueContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductPrint> ProductPrints { get; set; }
        public DbSet<PavluqueOrderGenerator.Model.OrderItem> OrderItems { get; set; }
        public DbSet<PavluqueOrderGenerator.Model.Order> Orders { get; set; }

    }
}