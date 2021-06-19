using MongoReception.Domain.Entities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Common.Interfaces
{
    public interface IHandOverReportService
    {
        Task<HandOverReport> AddHandOverReport(HandOverReport handOverReport);

        Task<HandOverReport> GetHandOverReport(string id);

        Task<IEnumerable<HandOverReport>> GetAllHandOverReports();

        Task UpdateHandOverReport(HandOverReport handOverReport);

        Task DeleteHandOverReport(string id);

        Task AttachDetailsToHandOverReport(string handOverReportId, JObject rawDetails);

        Task AddHandOverReportWithDetails(JObject rawhandOverReportWithDetails);
    }
}