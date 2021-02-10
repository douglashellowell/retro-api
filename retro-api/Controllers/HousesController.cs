using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using retro_api.Models;

namespace retro_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HousesController : ControllerBase
    {
 
        private readonly ILogger<HousesController> _logger;
        private readonly IConfiguration _config;

        public HousesController(ILogger<HousesController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("all")]
        [HttpGet]

        public ActionResult<List<House>> Get()
        {
           var houses = HouseModel.GetHouses();

            if (houses == null)
            {
                return StatusCode(500);
            }
            else
            {
                return houses;
            }
         
        }
    }

    public class CustomError : Exception
    {
        public HttpStatusCode errorCode;
        public CustomError(HttpStatusCode errCode)
        {
            errorCode = errCode;
        }
    }
}
