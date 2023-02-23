namespace Yannik.LangLearn.API.Options
{
    public class MongoDBOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string MultipleChoiceCollectionName { get; set; } = string.Empty;
    }
}