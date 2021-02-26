using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Net.Http;
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

        private IHousesModel _houseModel;
        private IStudentsModel _studentsModel;

        public HousesController(ILogger<HousesController> logger, IConfiguration config, IHousesModel housesModel, IStudentsModel studentsModel)
        {
            _logger = logger;
            _houseModel = housesModel;
            _studentsModel = studentsModel;
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<House>> GetAllHouses()
        {
            var houses = _houseModel.GetHouses();

            if (houses == null)
            {
                return StatusCode(500, new ApiResponse(500));
            }
            else
            {
                return houses;
            }

        }

        [Route("")]
        [HttpPost]
        public ActionResult<House> PostHouse(HouseRequest newHouse)
        {
            // TODO need error handling

            var insertedHouse = _houseModel.InsertHouse(newHouse);

            if (insertedHouse == null)
            {
                return BadRequest(new ApiResponse(400, "post failed :O"));
            }
            else
            {
                return insertedHouse;
            }
        }


        [Route("{id}")]
        [HttpGet]
        public ActionResult<House> GetHouseById(int id)
        {
            var house = _houseModel.GetHouseById(id);

            if (house == null)
            {
                var error = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("House does not exist :(", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                return NotFound(new ApiResponse(404, $"House {id} dun exit"));
            }
            else
            {
                return house;
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteHouseById(int id)
        {
            bool houseHasBeenDeleted = _houseModel.DeleteHouse(id);

            if (houseHasBeenDeleted)
            {
                return StatusCode(204);
            }
            else
            {
                return NotFound(new ApiResponse(404, $"House {id} dun eggist"));
            }
        }

        [Route("students")]
        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents(string id)
        {
            var students = _studentsModel.SelectAllStudents();
            if (students == null)
            {
                return NotFound(new ApiResponse(404, "there are no students... :S"));
            }
            else
            {
                return students;
            }
        }

        [Route("{id}/students")]
        [HttpGet]
        public ActionResult<List<Student>> GetStudentsByHouseId(int id)
        {
            var students = _studentsModel.SelectStudentsByHouseId(id);
            if (students.Count == 0)
            {
                return NotFound(new ApiResponse(404, $"house {id} isn't a thing"));
            }
            else
            {
                return students;
            }
        }

        [Route("{id}/students")]
        [HttpPost]
        public ActionResult<Student> PostStudent(int id, StudentRequest newStudent)
        {
            Student insertedStudent = _studentsModel.InsertStudent(id, newStudent);

            return insertedStudent;
        }
    }

}
