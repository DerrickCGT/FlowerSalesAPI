using FlowerSales.Models;


namespace FlowerSales.Services
{
    public static class MongoDBConverter
    {
        public static Product ConvertToBSONProduct(ProductEF product)
        {
            return new Product
            {                
                name = product.Name,
                storeLocation = product.StoreLocation,
                postcode = product.PostCode,
                price = product.Price,
                isAvailable = product.IsAvailable,
                categoryName = product.CategoryId.ToString()
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
