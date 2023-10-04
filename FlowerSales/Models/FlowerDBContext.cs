using Microsoft.EntityFrameworkCore;

namespace FlowerSales.Models
{
    public class FlowerDBContext: DbContext
    {
        public FlowerDBContext(DbContextOptions<FlowerDBContext> options) : base(options)       {        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
