using MongoDB.Bson;
using MongoReception.Domain.Entities;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Common.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task AttachExtras(string roomId, BsonArray extras);

        Task AddWithExtras(Room room, BsonArray extras);
    }
}
