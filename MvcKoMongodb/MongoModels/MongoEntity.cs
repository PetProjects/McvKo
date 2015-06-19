using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MvcKoMongodb.MongoModels
{    
    public class MongoEntity : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
