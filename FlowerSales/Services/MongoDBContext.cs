using MongoDB.Bson;
using MongoDB.Driver;
using FlowerSales.Models;
using Microsoft.Extensions.Options;

namespace FlowerSales.Services
{
    public class MongoDBContext
    {
        // Initialise _productCollection using MongoDB Driver type IMongoCollection
        public IMongoCollection<Product> _productCollection;
        public IMongoCollection<Category> _categoryCollection;

        public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            // Create instance of MongoClient using ConnectionURI
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            // Create instance of Database and getDatabase from MongoCLient ("flowers_db")
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);

            // Passing collection ("products") from MongoDB Databse ("flowers_db")
            _productCollection = database.GetCollection<Product>(mongoDBSettings.Value.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(mongoDBSettings.Value.CategoryCollectionName);
            
        }

    }
}
