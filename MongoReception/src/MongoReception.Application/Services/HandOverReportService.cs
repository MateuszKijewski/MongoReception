using MongoDB.Bson;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Services
{
    public class HandOverReportService : IHandOverReportService
    {
        private readonly IHandOverReportRepository _handOverReportRepository;

        public HandOverReportService(IHandOverReportRepository handOverReportRepository)
        {
            _handOverReportRepository = handOverReportRepository;
        }

        public async Task<HandOverReport> AddHandOverReport(HandOverReport handOverReport)
        {
            return await _handOverReportRepository.Add(handOverReport);
        }        

        public async Task DeleteHandOverReport(string id)
        {
            await _handOverReportRepository.Delete(id);
        }

        public async Task<IEnumerable<HandOverReport>> GetAllHandOverReports()
        {
            return await _handOverReportRepository.List();
        }

        public async Task<HandOverReport> GetHandOverReport(string id)
        {
            return await _handOverReportRepository.Get(id);
        }

        public async Task UpdateHandOverReport(HandOverReport handOverReport)
        {
            await _handOverReportRepository.Update(handOverReport);
        }

        public async Task AddHandOverReportWithDetails(JObject rawhandOverReportWithDetails)
        {
            var rawHandOverReport = rawhandOverReportWithDetails["handOverReport"];
            var rawDetails = rawhandOverReportWithDetails["rawDetails"];

            var handOverReport = rawHandOverReport.ToObject<HandOverReport>();
            var details = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(rawDetails.ToString());

            await _handOverReportRepository.AddWithDetails(handOverReport, details);
        }

        public async Task AttachDetailsToHandOverReport(string handOverReportId, JObject rawDetails)
        {
            var details = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonArray>(rawDetails.ToString());

            await _handOverReportRepository.AttachDetails(handOverReportId, details);
        }
    }
}
