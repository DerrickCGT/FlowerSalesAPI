using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FlowerSales.Services;
using Microsoft.Extensions.Options;

namespace FlowerSales.Models
{
    public class FlowerDBContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public FlowerDBContext(DbContextOptions<FlowerDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEF>()
                .HasMany(c => c.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Seed();

            var mongoDBSettings = _configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            var mongoDBContext = new MongoDBContext(Options.Create(mongoDBSettings));

            foreach (var categoryEF in CategoryEF)
            {
                var category = MongoDBConverter.ConvertToBSONCategory(categoryEF);
                mongoDBContext._categoryCollection.InsertOne(category);

                foreach (var productEF in categoryEF.Products)
                {
                    var product = MongoDBConverter.ConvertToBSONProduct(productEF);
                    mongoDBContext._productCollection.InsertOne(product);
                }
            }

        }

        public DbSet<ProductEF> ProductsEF { get; set; }
        public DbSet<CategoryEF> CategoryEF { get; set; }

    }
}
