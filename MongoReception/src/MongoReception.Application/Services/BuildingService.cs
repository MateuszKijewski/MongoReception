using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Contracts.Buildings;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<Building> AddBuilding(Building building)
        {
            building.Location = GeoJson.Point(GeoJson.Geographic(building.Longitude, building.Latitude));

            return await _buildingRepository.Add(building);
        }

        public async Task DeleteBuilding(string id)
        {
            await _buildingRepository.Delete(id);
        }

        public async Task<IEnumerable<Building>> GetAllBuildings()
        {
            return await _buildingRepository.List();
        }

        public async Task<Building> GetBuilding(string id)
        {
            return await _buildingRepository.Get(id);
        }

        public async Task UpdateBuilding(Building building)
        {
            await _buildingRepository.Update(building);
        }

        public async Task AttachExtrasToBuilding(string buildingId, JObject rawExtras)
        {
            var extras = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(rawExtras.ToString());

            await _buildingRepository.AttachExtras(buildingId, extras);
        }

        public async Task AddBuildingWithExtras(JObject rawBuildingWithExtras)
        {

            var rawBuilding = rawBuildingWithExtras["building"];
            var rawExtras = rawBuildingWithExtras["rawExtras"];

            var building = rawBuilding.ToObject<Building>();
            var extras = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(rawExtras.ToString());

            await _buildingRepository.AddWithExtras(building, extras);
        }

        public async Task<IEnumerable<Building>> FindBuildingsNearClient(GeoLocalizationContract clientLocation)
        {            
            return await _buildingRepository.FindNear(clientLocation.Longitude, clientLocation.Latitude);
        }
    }
}
