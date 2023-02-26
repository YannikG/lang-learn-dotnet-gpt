using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Yannik.LanLearn.Core.Models.Database
{
    public class BaseDatabaseEntityModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null;
    }
}