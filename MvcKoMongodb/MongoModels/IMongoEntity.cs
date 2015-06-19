using MongoDB.Bson;

namespace MvcKoMongodb.MongoModels
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
