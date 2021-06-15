﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoReception.Domain.Common.Interfaces;

namespace MongoReception.Domain.Entities
{
    public class Building : IMongoEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string StreetName { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string HouseNumber { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string City { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string ZipCode { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Latitude { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Longitude { get; set; }

        public BsonDocument Extras { get; set; }

        public string GetCollectionName()
        {
            return "Buildings";
        }
    }
}