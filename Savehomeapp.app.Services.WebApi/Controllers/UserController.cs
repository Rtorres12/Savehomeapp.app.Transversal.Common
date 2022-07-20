using Exphadis.app.Application.DTO;
using Exphadis.app.Application.Interface;
using Exphadis.app.Services.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Savehomeapp.app.Transversal.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Exphadis.app.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly AppSettings _appSettings;
        public UserController(IUserApplication userApplication,IOptions<AppSettings> appSettings)
        {
            _userApplication = userApplication;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Insert([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();

            }
            else
            {
                var response = _userApplication.Insert(userDTO);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else { return BadRequest(response.Message); }
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UserDTO authDto) {
            var response = _userApplication.Autheticate(authDto.Username, authDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data !=null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }

            }
            return BadRequest(response.Message);

          
        }
        private string BuildToken(Response<UserDTO> userDTO)
        {
           var claims = new ClaimsIdentity();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userDTO.Data.Id.ToString()));

            var tokenDescription = new SecurityTokenDescriptor(){
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
