using Exphadis.app.Application.DTO;
using Exphadis.app.Application.Interface;
using Exphadis.app.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exphadis.app.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]

    public class CourseBookingController : Controller
    {
        private readonly ICourseBookingApplication _courseBookingApplication;

        public CourseBookingController(ICourseBookingApplication courseBookingApplication)
        {
            _courseBookingApplication = courseBookingApplication;
        }
        [HttpGet("{id}")]
        public IActionResult CoursesByuserId(int id)
        {
            var response = _courseBookingApplication.GetByIdUser(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _courseBookingApplication.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
        [HttpPost]
        public IActionResult Insert([FromBody] CourseBookingDTO course)
        {
            var response = _courseBookingApplication.Insert(course);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
    }
}
