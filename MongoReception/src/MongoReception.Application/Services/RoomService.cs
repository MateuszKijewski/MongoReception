using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IBaseRepository<Room> _roomRepository;

        public RoomService(IBaseRepositoryProvider repositoryProvider)
        {
            _roomRepository = repositoryProvider.GetRepository<Room>();
        }

        public async Task<Room> AddRoom(Room room)
        {
            return await _roomRepository.Add(room);
        }

        public async Task DeleteRoom(string id)
        {
            await _roomRepository.Delete(id);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _roomRepository.List();
        }

        public async Task<Room> GetRoom(string id)
        {
            return await _roomRepository.Get(id);
        }

        public async Task UpdateRoom(Room room)
        {
            await _roomRepository.Update(room);
        }
    }
}
