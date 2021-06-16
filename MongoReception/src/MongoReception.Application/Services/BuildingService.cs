using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBaseRepository<Building> _buildingRepository;

        public BuildingService(IBaseRepositoryProvider repositoryProvider)
        {
            _buildingRepository = repositoryProvider.GetRepository<Building>();
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
    }
}
