using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoRedo.Model
{
    public class AccountType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int AccountNumber { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
