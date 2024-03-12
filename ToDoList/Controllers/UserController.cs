using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models.InputModels;
using ToDoList.Persistence;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPut("login")]
        public IActionResult Login([FromBody] InputLogin login)
        {
            try
            {
                var token = _userService.Login(login);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(InputUser createUser)
        {
            var user = _userService.CreateUser(createUser);
            return Ok(user);
            //return CreatedAtAction(nameof(GetById), new { task.Id }, task);
        }
    }
}
