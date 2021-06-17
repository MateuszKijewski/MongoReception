using MongoReception.Domain.Entities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Common.Interfaces
{
    public interface IBuildingService
    {
        Task<Building> AddBuilding(Building building);

        Task<Building> GetBuilding(string id);

        Task<IEnumerable<Building>> GetAllBuildings();

        Task UpdateBuilding(Building building);

        Task DeleteBuilding(string id);

        Task AttachExtrasToBuilding(string buildingId, string rawExtras);

        Task AddBuildingWithExtras(JObject rawBuildingWithExtras);
    }
}
