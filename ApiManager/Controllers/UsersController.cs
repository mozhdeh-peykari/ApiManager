using ApiManager.Models;
using ApiManager.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IJwtService jwtService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService,IJwtService jwtService, IMapper mapper)
        {
            this.userService = userService;
            this.jwtService = jwtService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Generates a JWT token for authentication
        /// </summary>
        /// <param name="authenticateModel">User's Username and Password</param>
        /// <returns>a JWT token string</returns>
        /// <response code="200">Returns a JWT token</response>
        /// <response code="401">Invalid Username or Password</response>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> GetToken([FromBody] AuthenticateModel authenticateModel)
        {
            var user = await userService.GetByUserAndPasswordAsync(authenticateModel.Username, authenticateModel.Password);
            if (user == null)
                return Unauthorized("Incorrect Username or Password");
            var token = jwtService.GenerateToken(user);
            return Ok(token);
        }
        /// <summary>
        /// Returns the list of all users
        /// </summary>
        /// <returns>List of all users</returns>
        /// <response code="200">Returns a list of all users</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userService.GetAllAsync();
            var userDtoList = mapper.Map<List<UserDto>>(users);
            return Ok(userDtoList);
        }
    }
}
