using MongoDB.Bson;
using MongoDB.Driver;
using MongoReception.DataAccess.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using MongoReception.Infrastructure.Common.Repositories;
using System;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(IReceptionDatabaseSettings settings)
            : base(settings)
        {
        }

        public async Task AttachExtras(string roomId, BsonArray extras)
        {
            var filter = Builders<Room>.Filter.Eq(nameof(Room.Id), roomId);
            var update = Builders<Room>.Update.Set(nameof(Room.Extras), extras);

            await _entityCollection.UpdateOneAsync(filter, update);
        }

        public async Task<Room> AddWithExtras(Room room, BsonArray extras)
        {
            using (var session = _mongoClient.StartSession())
            {
                try
                {
                    session.StartTransaction();

                    var addedRoom = await Add(room);
                    await AttachExtras(addedRoom.Id, extras);

                    session.CommitTransaction();

                    return addedRoom;
                }
                catch (Exception)
                {
                    session.AbortTransaction();
                    throw;
                }
            }
        }
    }
}