using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlowerSales.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string Name { get; set; } = null!;
        public string StoreLocation { get; set; } = null!;
        public int PostCode { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; } 

    }
}
