using ApiManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        /// <summary>
        /// Generates a JWT token for authentication
        /// </summary>
        /// <param name="username">Username of the User</param>
        /// <param name="password">Password of the User</param>
        /// <returns>a JWT token string</returns>
        /// <response code="200">Returns a JWT token</response>
        /// <response code="400">Invalid Username or Password</response>
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetToken(string username, string password)
        {
            var user = userService.GetByUserAndPassword(username, password);
            if (user == null)
                return BadRequest("Incorrect Username or Password");
            var token = userService.GenerateToken(user);
            return Ok(token);
        }
        /// <summary>
        /// Returns the list of all users
        /// </summary>
        /// <returns>List of all users</returns>
        /// <response code="200">Returns a list of all users</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userService.GetAll();
            return Ok(users);
        }
    }
}
