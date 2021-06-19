using Microsoft.AspNetCore.Mvc;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.WebApi.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace MongoReception.WebApi.Controllers
{
    public class HandOverReportController : Controller
    {
        private readonly IHandOverReportService _handOverReportService;
        public HandOverReportController(IHandOverReportService handOverReportService)
        {
            _handOverReportService = handOverReportService;
        }

        [HttpGet(ApiRoutes.HandOverReport.Specific)]
        public async Task<IActionResult> Get([FromRoute] string handOverReportId)
        {
            try
            {
                var requestedHandOverReport = await _handOverReportService.GetHandOverReport(handOverReportId);

                return Ok(requestedHandOverReport);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete(ApiRoutes.HandOverReport.Specific)]
        public async Task<IActionResult> Delete([FromRoute] string handOverReportId)
        {
            try
            {
                await _handOverReportService.DeleteHandOverReport(handOverReportId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut(ApiRoutes.HandOverReport.Specific)]
        public async Task<IActionResult> Update([FromRoute] HandOverReport handOverReport)
        {
            try
            {
                await _handOverReportService.UpdateHandOverReport(handOverReport);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet(ApiRoutes.HandOverReport.Main)]
        public async Task<IActionResult> List()
        {
            try
            {
                var requestedHandOverReports = await _handOverReportService.GetAllHandOverReports();

                return Ok(requestedHandOverReports);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.HandOverReport.Main)]
        public async Task<IActionResult> Add([FromBody] HandOverReport handOverReport)
        {
            try
            {
                await _handOverReportService.AddHandOverReport(handOverReport);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost(ApiRoutes.HandOverReport.AttachDetails)]
        public async Task<IActionResult> AttachDetails([FromRoute] string handOverReportId, [FromBody] JObject rawDetails)
        {
            try
            {
                await _handOverReportService.AttachDetailsToHandOverReport(handOverReportId, rawDetails);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.HandOverReport.Details)]
        public async Task<IActionResult> AddWithExtras([FromBody] JObject rawHandOverReportWithExtras)
        {
            try
            {
                await _handOverReportService.AddHandOverReportWithDetails(rawHandOverReportWithExtras);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
