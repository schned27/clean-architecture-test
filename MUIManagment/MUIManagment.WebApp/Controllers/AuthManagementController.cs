using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MUIManagement.WebApp.Configuration.JwtConfig;
using System.Threading.Tasks;
using MUIManagement.Infrastructure.Database.Entities.Requests;
using MUIManagement.Infrastructure.Database.Entities.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MUIManagement.WebApp.Middleware;

namespace MUIManagement.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        public AuthManagementController(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest user)
        {
            if(ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if(existingUser != null)
                {

                    throw new AppException($"E-Mail address already exists");

                    //return BadRequestResult(new RegistrationResponse()
                    //{
                    //    Success = false,
                    //    Errors = new List<string>()
                    //    {
                    //        "E-Mail-Adresse existiert bereits."
                    //    }
                    //});
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);

                if(isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);

                    return new JsonResult(new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }

                return new JsonResult(new RegistrationResponse()
                {
                    Success = false,
                    Errors = isCreated.Errors.Select(x => x.Description).ToList()
                } ) { StatusCode = 500 };
            }

            return new JsonResult(new RegistrationResponse()
            {
                Success = false,
                Errors = new List<string> {
                    "Invalid Payload"
                }
            });
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
