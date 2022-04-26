using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Application.Interface;
namespace Savehomeapp.app.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductsApplication _productsApplication;
        public ProductsController(IProductsApplication productsApplication)
        {
            _productsApplication = productsApplication;
        }
        [HttpPost]
        public IActionResult Insert([FromBody] ProductsDTO products)
        {
            if (products == null)
            {
                return BadRequest();
                
            }
            else {
                var response = _productsApplication.Insert(products);
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

    }
}
