using MongoDB.Bson;
using MongoReception.Application.Common.Interfaces;
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

        public async Task AttachExtrasToBuilding(string buildingId, string rawExtras)
        {
            var extras = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(rawExtras);

            await _buildingRepository.AttachExtras(buildingId, extras);
        }

        public async Task AddBuildingWithExtras(JObject rawBuildingWithExtras)
        {

            var rawBuilding = rawBuildingWithExtras["building"];
            var rawExtras = rawBuildingWithExtras["rawExtras"];

            var building = rawBuilding.ToObject<Building>();
            var extrasObject = rawExtras.ToString();
            var extras = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(extrasObject);

            await _buildingRepository.AddWithExtras(building, extras);
        }
    }
}
