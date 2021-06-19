﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoReception.Domain.Common.Interfaces;

namespace MongoReception.Domain.Entities
{
    public class Building : IMongoEntity
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Image { get; set; }

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

        public BsonArray Extras { get; set; }

        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }

        public string GetCollectionName()
        {
            return "Buildings";
        }
    }
}