using Microsoft.AspNetCore.Mvc;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Contracts.Users;
using MongoReception.Domain.Entities;
using MongoReception.WebApi.Helpers;
using System;
using System.Threading.Tasks;

namespace MongoReception.WebApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(ApiRoutes.User.Specific)]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            try
            {
                var requestedUser = await _userService.GetUser(userId);

                return Ok(requestedUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet(ApiRoutes.User.Main)]
        public async Task<IActionResult> List()
        {
            try
            {
                var requestedUsers = await _userService.GetAllUsers();

                return Ok(requestedUsers);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.User.Register)]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var requestedUser = await _userService.Register(user);

                return Ok(requestedUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.User.Login)]
        public async Task<IActionResult> Login([FromBody] LoginContract loginContract)
        {
            try
            {
                var authenticatedUser = await _userService.Authenticate(loginContract);

                if (authenticatedUser != null)
                {
                    return Ok(authenticatedUser);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
