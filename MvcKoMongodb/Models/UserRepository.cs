using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MvcKoMongodb.MongoModels;

namespace MvcKoMongodb.Models
{
    public static class UserRepository
    {

        private static IMongoCollection<User> _users;

        private static IMongoCollection<User> Users
        {
            get
            {
                if (_users != null) 
                    return _users;

                var connectionString = "mongodb://localhost";
                var mongoClient = new MongoClient(connectionString);
                var db = mongoClient.GetDatabase("mvcko1");

                return _users = db.GetCollection<User>("users");                
            }
        }

        public static async Task<IEnumerable<User>> GetUser()
        {
            List<User> res = new List<User>();
            using (var cursor = await Users.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                    res.AddRange(cursor.Current);                
            }
            return res;
        }

        public static User GetUser(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", new ObjectId(id));
            return Users.Find(filter).ToListAsync().Result.FirstOrDefault();
        }

        public static void InsertUser(User user)
        {
            Users.InsertOneAsync(user);
        }

        public static async Task DeleteUser(string userId)
        {
            var filter = Builders<User>.Filter.Eq("_id", new ObjectId(userId));
            await Users.DeleteManyAsync(filter);
        }
    }
}
