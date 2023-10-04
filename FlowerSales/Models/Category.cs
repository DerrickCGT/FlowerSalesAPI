using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FlowerSales.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string? Id { get; set; } 

        [BsonElement("CategoryName")]
        public string CategoryName { get; set; } 

        [BsonIgnoreIfDefault]
        public List<Product> Products { get; set; }
    }
}
