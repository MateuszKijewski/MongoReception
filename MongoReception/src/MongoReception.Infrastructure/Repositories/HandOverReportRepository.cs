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
    public class HandOverReportRepository : BaseRepository<HandOverReport>, IHandOverReportRepository
    {
        public HandOverReportRepository(IReceptionDatabaseSettings settings)
            : base(settings)
        {
        }        

        public async Task AttachDetails(string handOverReportId, BsonArray details)
        {
            var filter = Builders<HandOverReport>.Filter.Eq(nameof(HandOverReport.Id), handOverReportId);
            var update = Builders<HandOverReport>.Update.Set(nameof(HandOverReport.Details), details);

            await _entityCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddWithDetails(HandOverReport handOverReport, BsonArray details)
        {
            using (var session = _mongoClient.StartSession())
            {
                try
                {
                    session.StartTransaction();

                    var addedHandOverReport = await Add(handOverReport);
                    await AttachDetails(addedHandOverReport.Id, details);

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
