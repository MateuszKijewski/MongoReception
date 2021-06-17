using MongoDB.Bson;
using MongoReception.Domain.Entities;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Common.Interfaces
{
    public interface IBuildingRepository : IBaseRepository<Building>
    {
        Task AttachExtras(string buildingId, BsonArray extras);

        Task AddWithExtras(Building building, BsonArray extras);
    }
}
