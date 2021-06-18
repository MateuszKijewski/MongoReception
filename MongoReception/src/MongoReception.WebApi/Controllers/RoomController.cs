using Microsoft.AspNetCore.Mvc;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.WebApi.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace MongoReception.WebApi.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet(ApiRoutes.Room.Specific)]
        public async Task<IActionResult> Get([FromRoute] string roomId)
        {
            try
            {
                var requestedRoom = await _roomService.GetRoom(roomId);

                return Ok(requestedRoom);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete(ApiRoutes.Room.Specific)]
        public async Task<IActionResult> Delete([FromRoute] string roomId)
        {
            try
            {
                await _roomService.DeleteRoom(roomId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut(ApiRoutes.Room.Specific)]
        public async Task<IActionResult> Update([FromRoute] Room room)
        {
            try
            {
                await _roomService.UpdateRoom(room);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet(ApiRoutes.Room.Main)]
        public async Task<IActionResult> List()
        {
            try
            {
                var requestedRooms = await _roomService.GetAllRooms();

                return Ok(requestedRooms);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Room.Main)]
        public async Task<IActionResult> Add([FromBody] Room room)
        {
            try
            {
                await _roomService.AddRoom(room);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Room.AttachExtras)]
        public async Task<IActionResult> AttachExtras([FromRoute] string roomId, [FromBody] JObject rawExtras)
        {
            try
            {
                await _roomService.AttachExtrasToRoom(roomId, rawExtras);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Room.Extras)]
        public async Task<IActionResult> AddWithExtras([FromBody] JObject rawRoomWithExtras)
        {
            try
            {
                await _roomService.AddRoomWithExtras(rawRoomWithExtras);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
