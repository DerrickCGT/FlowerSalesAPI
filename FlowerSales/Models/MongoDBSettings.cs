namespace FlowerSales.Models
{
    public class MongoDBSettings
    {
        // Class for MongoDBSettings as per appsettings.json
        // Implemented under program.cs where passing appsettings.json data to MongoDBSettings
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }

    }

}
