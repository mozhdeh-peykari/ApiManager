using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiManager.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns a specific text
        /// </summary>
        /// <returns>a string</returns>
        /// <response code="200">Returns a specific text</response>

        [HttpGet]
        public string Get()
        {
            return "Hi babe!";
        }

    }
}
