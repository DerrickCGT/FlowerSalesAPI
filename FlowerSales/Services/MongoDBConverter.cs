using FlowerSales.Models;


namespace FlowerSales.Services
{
    public static class MongoDBConverter
    {
        public static Product ConvertToBSONProduct(ProductEF product)
        {
            return new Product
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                StoreLocation = product.StoreLocation,
                PostCode = product.PostCode,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                CategoryId = product.CategoryId.ToString()
            };
        }

        public static Category ConvertToBSONCategory(CategoryEF category)
        {
            return new Category
            {
                Id = category.Id.ToString(),
                CategoryName = category.CategoryName,

            };
        }
    }
}
