using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Attribute> Product_Attributes { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<PricesArchive> PricesArchives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }
        public DbSet<Preset> Presets { get; set; }
        public DbSet<Preset_Attribute> Preset_Attributes { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }
    }
}
