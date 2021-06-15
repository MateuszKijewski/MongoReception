using MongoReception.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Common.Interfaces
{
    public interface IRoomService
    {
        Task<Room> AddRoom(Room room);

        Task<Room> GetRoom(string id);

        Task<IEnumerable<Room>> GetAllRooms();

        Task UpdateRoom(Room room);

        Task DeleteRoom(string id);
    }
}
