using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoReception.Domain.Common.Interfaces;

namespace MongoReception.Domain.Entities
{
    public class Room : IMongoEntity
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Number { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Image { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int Floor { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal PricePerDay { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string BuildingId { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsAvailable { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsDamaged { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsClean { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsRent { get; set; }

        public BsonArray Extras { get; set; }

        public string GetCollectionName()
        {
            return "Rooms";
        }
    }
}