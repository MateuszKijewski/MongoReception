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
    public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(IReceptionDatabaseSettings settings)
            : base(settings)
        {
        }
        public async Task AttachExtras(string buildingId, BsonArray extras)
        {
            var filter = Builders<Building>.Filter.Eq(nameof(Building.Id), buildingId);
            var update = Builders<Building>.Update.Set(nameof(Building.Extras), extras);

            await _entityCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddWithExtras(Building building, BsonArray extras)
        {
            using (var session = _mongoClient.StartSession())
            {
                try
                {
                    session.StartTransaction();

                    var addedBuilding = await Add(building);
                    await AttachExtras(addedBuilding.Id, extras);

                    session.CommitTransaction();
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
