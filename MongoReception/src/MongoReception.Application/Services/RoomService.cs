using MongoDB.Bson;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
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

        public async Task AttachExtrasToRoom(string roomId, JObject rawExtras)
        {
            var extras = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(rawExtras.ToString());

            await _roomRepository.AttachExtras(roomId, extras);
        }

        public async Task AddRoomWithExtras(JObject rawRoomWithExtras)
        {

            var rawRoom = rawRoomWithExtras["room"];
            var rawExtras = rawRoomWithExtras["rawExtras"];

            var room = rawRoom.ToObject<Room>();
            var extras = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(rawExtras.ToString());

            await _roomRepository.AddWithExtras(room, extras);
        }
    }
}
