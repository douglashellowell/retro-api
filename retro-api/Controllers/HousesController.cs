using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using retro_api.Interfaces;
using retro_api.Models;

namespace retro_api.Controllers
{
    [ApiController]
    [Route("houses")]
    public class HousesController : ControllerBase
    {

        private readonly ILogger<HousesController> _logger;
        //private readonly IConfiguration _config;

        private IPotterContext _potterContext;
        private IHousesModel _houseModel;

        public HousesController(ILogger<HousesController> logger, IConfiguration config, IHousesModel housesModel)
        {
            _logger = logger;
            //_config = config;
            //_potterContext = new PotterContext();
            _houseModel = housesModel;
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<House>> GetAllHouses()
        {
            //string host = _config.GetValue<string>("dbConfig:host");
            //string database = _config.GetValue<string>("");
            var houses = _houseModel.GetHouses();

            if (houses == null)
            {
                return StatusCode(500);
            }
            else
            {
                return houses;
            }

        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<List<House>> GetHouseById(string id)
        {
            var house = _houseModel.GetHouseById(id);

            if(house.Count == 0)
            {
                return StatusCode(404);
            } else
            {
                return house;
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
