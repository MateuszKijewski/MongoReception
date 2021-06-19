using MongoDB.Bson;
using MongoReception.Domain.Entities;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Common.Interfaces
{
    public interface IHandOverReportRepository : IBaseRepository<HandOverReport>
    {
        Task AttachDetails(string handOverReportId, BsonArray details);

        Task AddWithDetails(HandOverReport handOverReport, BsonArray details);
    }
}
