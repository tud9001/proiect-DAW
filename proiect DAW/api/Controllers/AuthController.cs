using Microsoft.AspNetCore.Mvc;
using api.autorizare;
using Domain;
using api.Models.Users;
using api.Services;
using System;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [Authorize(role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            // only admins can access other user records
            var currentUser = (user)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.role != role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var user =  _userService.GetById(id);
            return Ok(user);
        }
    }
}