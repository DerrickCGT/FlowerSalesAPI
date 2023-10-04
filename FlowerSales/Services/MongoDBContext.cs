using MongoDB.Bson;
using MongoDB.Driver;
using FlowerSales.Models;
using Microsoft.Extensions.Options;

namespace FlowerSales.Services
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            _database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);            
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("products");
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("category");
    }
}
