using Microsoft.AspNetCore.Mvc;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.WebApi.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace MongoReception.WebApi.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet(ApiRoutes.Building.Specific)]
        public async Task<IActionResult> Get([FromRoute] string buildingId)
        {
            try
            {
                var requestedBuilding = await _buildingService.GetBuilding(buildingId);

                return Ok(requestedBuilding);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete(ApiRoutes.Building.Specific)]
        public async Task<IActionResult> Delete([FromRoute] string buildingId)
        {
            try
            {
                await _buildingService.DeleteBuilding(buildingId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut(ApiRoutes.Building.Specific)]
        public async Task<IActionResult> Update([FromRoute] Building building)
        {
            try
            {
                await _buildingService.UpdateBuilding(building);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet(ApiRoutes.Building.Main)]
        public async Task<IActionResult> List()
        {
            try
            {
                var requestedBuildings = await _buildingService.GetAllBuildings();

                return Ok(requestedBuildings);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Building.Main)]
        public async Task<IActionResult> Add([FromBody] Building building)
        {
            try
            {
                await _buildingService.AddBuilding(building);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost(ApiRoutes.Building.AttachExtras)]
        public async Task<IActionResult> AttachExtras([FromRoute] string buildingId, [FromBody] JObject rawExtras)
        {
            try
            {
                await _buildingService.AttachExtrasToBuilding(buildingId, rawExtras);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Building.Extras)]
        public async Task<IActionResult> AddWithExtras([FromBody] JObject rawBuildingWithExtras)
        {
            try
            {                
                await _buildingService.AddBuildingWithExtras(rawBuildingWithExtras);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
