using MongoDB.Bson.Serialization.Attributes;

namespace MvcKoMongodb.MongoModels
{
    [BsonIgnoreExtraElements]
    public class User : MongoEntity
    {
        [BsonElement("name")]
        public string FirstName { get; set; }
        [BsonElement("lastname")]
        public string LastName { get; set; }
        [BsonElement("age")]
        public short Age { get; set; }
        [BsonElement("desc")]
        public string Description { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; }
    }
}
