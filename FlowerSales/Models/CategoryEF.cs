namespace FlowerSales.Models
{
    public class CategoryEF
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public virtual List<ProductEF> Products { get; set; }
    }
}
