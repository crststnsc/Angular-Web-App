namespace brta.Models
{
    public class MongoDBSettings : Settings.IMongoDBSettings
    {
        public string AnnouncementsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
