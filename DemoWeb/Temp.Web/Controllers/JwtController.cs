using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.Service;
using Temp.Service.ViewModel;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// jwt authentication
    /// </summary>
    [Route("api/[controller]")]
    public class JwtController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IAccountService _service;

        public JwtController(IConfiguration config, IAccountService service)
        {
            _config = config;
            _service = service;
        }
        
        /// <summary>
        /// login
        /// </summary>
        /// <param name="logInDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LogInViewModel logInDto)
        {
            IActionResult response = Unauthorized();  
            var user = _service.LogIn(logInDto);  
  
            if (user != null)  
            {  
                var tokenString = GenerateJwt(user);  
                response = Ok(new { token = tokenString });  
            }  
  
            return response;
        }
        
        /// <summary>
        /// generate jwt
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));  
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);  
  
            var claims = new[] {  
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),                  
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  
            };  
  
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],  
                _config["Jwt:Issuer"],  
                claims,  
                expires: DateTime.Now.AddMinutes(120),  
                signingCredentials: credentials);  
  
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }
    }
}
