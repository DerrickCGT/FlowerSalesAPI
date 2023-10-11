using FlowerSales.Services;
using MongoDB.Driver;

namespace FlowerSales.Models
{
    public class FlowerDBSeed
    {
        private readonly IMongoCollection<Product> _productCollection;

        public FlowerDBSeed(MongoDBContext dbContext)
        {
            _productCollection = dbContext._productCollection;
        }

        public void SeedProductsIfNotExists()
        {
            var collectionNames = _productCollection.Database.ListCollectionNames().ToList();
            if (!collectionNames.Contains("products"))
            {
                // Define your product data here
                var products = new List<Product>
                {
                    new Product { name = "Flowers in the city", storeLocation = "Canning Vale", postcode = 6155, price = 68.0M, isAvailable = true, categoryName = "Bouquetes" },
                    new Product { categoryName = "Bouquetes", name = "Flowers in the city", storeLocation = "Canning Vale", postcode = 6155, price = 68, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "Gerberas", storeLocation = "Willeton", postcode = 6155, price = 35, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "Aziatic Lilies", storeLocation = "Palmyra", postcode = 6123, price = 33, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "European Lilies", storeLocation = "Melville", postcode = 6145, price = 125, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "Chrisantemum", storeLocation = "Canninghton", postcode = 6112, price = 60, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "Alstroemeria", storeLocation = "Waikiki", postcode = 6112, price = 95, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "Snapdragon small", storeLocation = "Tuart Hill", postcode = 6112, price = 65, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "V-Crocus", storeLocation = "Willeton", postcode = 6113, price = 65, isAvailable = true },
                    new Product { categoryName = "Bouquetes", name = "Crocus", storeLocation = "Armadale", postcode = 6114, price = 17, isAvailable = true },
                    new Product { categoryName = "Box Flowers", name = "Calla Lily", storeLocation = "Aubin Grove", postcode = 6115, price = 99, isAvailable = true },
                    new Product { categoryName = "Box Flowers", name = "Geranium small", storeLocation = "Darch", postcode = 6116, price = 0, isAvailable = false },
                    new Product { categoryName = "Box Flowers", name = "Grunge Skater Jeans", storeLocation = "Jonndana", postcode = 6117, price = 68, isAvailable = true },
                    new Product { categoryName = "Box Flowers", name = "Geranium Large", storeLocation = "Joonedaloop", postcode = 6112, price = 125, isAvailable = true },
                    new Product { categoryName = "Box Flowers", name = "Stretchy Dance Pants", storeLocation = "GEralton", postcode = 6118, price = 55, isAvailable = true },
                    new Product { categoryName = "Box Flowers", name = "Alstroemeria", storeLocation = "Piara Waters", postcode = 6121, price = 22, isAvailable = false },
                    new Product { categoryName = "Box Flowers", name = "Gerberas", storeLocation = "Byford", postcode = 6132, price = 95, isAvailable = true },
                    new Product { categoryName = "Box Flowers", name = "Marigold", storeLocation = "Dianella", postcode = 6342, price = 17, isAvailable = true },
                    new Product { categoryName = "Wrapps", name = "Azalea", storeLocation = "Leong", postcode = 6123, price = 2.8M, isAvailable = true },
                    new Product { categoryName = "Wrapps", name = "Lemon-LAzalea", storeLocation = "Fremantle", postcode = 6124, price = 2.8M, isAvailable = true },
                    new Product { categoryName = "Wrapps", name = "Zinnia", storeLocation = "BEaconsfield", postcode = 6125, price = 2.8M, isAvailable = false },
                    new Product { categoryName = "Wrapps", name = "Peach Zinnia", storeLocation = "North Freo", postcode = 6126, price = 2.8M, isAvailable = true },
                    new Product { categoryName = "Wrapps", name = "Raspberry Zinnia", storeLocation = "Munster", postcode = 6127, price = 2.8M, isAvailable = true },
                    new Product { categoryName = "Wrapps", name = "Snapdragon big", storeLocation = "Coogee", postcode = 6128, price = 2.8M, isAvailable = true },
                    new Product { categoryName = "Single Flower", name = " Petunia", storeLocation = "South Freo", postcode = 6129, price = 24.99M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Dahlia (long lasting)", storeLocation = "City", postcode = 6112, price = 9.99M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Dahlia", storeLocation = "West Perth", postcode = 6130, price = 12.49M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Orchid domestic", storeLocation = "East Perth", postcode = 6131, price = 13.99M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Orchid Expensive", storeLocation = "Bentley", postcode = 6132, price = 12.49M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Marigold", storeLocation = "Carslie", postcode = 6133, price = 9.99M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Gardenia type C", storeLocation = "Lathlain", postcode = 6134, price = 11.99M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Gardenia type-B", storeLocation = "Booragoon", postcode = 6135, price = 12.99M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Gardenia", storeLocation = "Applecross", postcode = 6136, price = 9.99M, isAvailable = true },
                    new Product { categoryName = "Additional", name = "Calla Lily", storeLocation = "Rockyngham", postcode = 6001, price = 12.49M, isAvailable = true },
                };

                // Create the "products" collection if it doesn't exist
                _productCollection.Database.CreateCollection("products");

                // Insert products into the database
                _productCollection.InsertMany(products);
            }
        }
    }
}
