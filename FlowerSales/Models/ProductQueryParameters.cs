namespace FlowerSales.Models
{
    public class ProductQueryParameters: QueryParameters
    {

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
         
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
