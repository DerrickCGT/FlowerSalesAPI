using System.Text.Json.Serialization;
    
namespace FlowerSales.Models
{
    public class ProductEF
    {
        public int Id { get; set; }      
        public string Name { get; set; } = string.Empty;
        public string StoreLocation { get; set; } = null!;
        public int PostCode { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        
        [JsonIgnore]
        public virtual CategoryEF? Category { get; set; }
    }
}
