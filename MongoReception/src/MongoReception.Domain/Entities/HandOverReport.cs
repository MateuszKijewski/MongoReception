using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoReception.Domain.Common.Interfaces;

namespace MongoReception.Domain.Entities
{
    public class HandOverReport : IMongoEntity
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string ReservationId { get; set; }

        public BsonArray Details { get; set; }

        public string GetCollectionName()
        {
            return "HandOverReports";
        }
    }
}
