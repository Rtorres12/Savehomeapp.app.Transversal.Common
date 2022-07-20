using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Application.Interface;
using Exphadis.app.Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Savehomeapp.app.Services.WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly ICoursesApplication _productsApplication;
        private readonly ICategorieApplication _categorieApplication;

        public CoursesController(ICoursesApplication productsApplication,ICategorieApplication categorieApplication)
        {
            _productsApplication = productsApplication;
            _categorieApplication = categorieApplication;
        }
        [HttpPost]
        public IActionResult Insert([FromBody] CoursesDTO courses)
        {
            if (courses == null)
            {
                return BadRequest();
                
            }
            else {
                var response = _productsApplication.Insert(courses);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else { return BadRequest(response.Message); }
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] CoursesDTO courses)
        {
            if (courses == null)
            {
                return BadRequest();

            }
            else
            {
                var response = _productsApplication.Delete(courses);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else { return BadRequest(response.Message); }
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] CoursesDTO courses)
        {
            if (courses == null)
            {
                return BadRequest();

            }
            else
            {
                var response = _productsApplication.Update(courses);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else { return BadRequest(response.Message); }
            }
        }
        [HttpGet]

        public IActionResult SelectAll()
        {
            
           
                var response = _productsApplication.GetList();
            var a = Request.HttpContext.Connection.RemoteIpAddress;
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else { return BadRequest(response.Message); }
            
        }
        [HttpGet]
        public IActionResult Categories()
        {
            var response = _categorieApplication.GetList();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else { return BadRequest(response.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult CoursesByCategorieId(int id)
        {
            var response = _productsApplication.GetByCategorieId(id);
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
