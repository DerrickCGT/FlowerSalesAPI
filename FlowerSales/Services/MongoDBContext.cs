using MongoDB.Bson;
using MongoDB.Driver;
using FlowerSales.Models;
using Microsoft.Extensions.Options;

namespace FlowerSales.Services
{
    public class MongoDBContext
    {
        public IMongoCollection<Product> _productCollection;
        public IMongoCollection<Category> _categoryCollection;

        public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _productCollection = database.GetCollection<Product>(mongoDBSettings.Value.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(mongoDBSettings.Value.CategoryCollectionName);
            
        }

    }
}
