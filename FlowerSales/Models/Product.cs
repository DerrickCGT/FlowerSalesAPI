using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlowerSales.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; } 
        public string name { get; set; } = null!;
        public string storeLocation { get; set; } = null!;
        public int postcode { get; set; }
        public decimal price { get; set; }
        public bool isAvailable { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        //public string? CategoryId { get; set; } 

        public string categoryName { get; set; } = null!;
    }
}
