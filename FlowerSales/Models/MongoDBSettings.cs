namespace FlowerSales.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }

    }

}
