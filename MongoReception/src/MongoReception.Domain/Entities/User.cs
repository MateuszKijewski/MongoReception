using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoReception.Domain.Common.Interfaces;

namespace MongoReception.Domain.Entities
{
    public class User : IMongoEntity
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string FirstName { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string LastName { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Password { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Phone { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string StreetName { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string HouseNumber { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string FlatNumber { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string City { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string ZipCode { get; set; }


        public string GetCollectionName()
        {
            return "Users";
        }
    }
}