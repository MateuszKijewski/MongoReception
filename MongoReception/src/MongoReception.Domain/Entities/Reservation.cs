using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoReception.Domain.Common.Interfaces;
using System;

namespace MongoReception.Domain.Entities
{
    public class Reservation : IMongoEntity
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Cost { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime StartDate { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EndDate { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsPaid { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool Active { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string RoomId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string ClientId { get; set; }

        public string GetCollectionName()
        {
            return "Reservations";
        }
    }
}
