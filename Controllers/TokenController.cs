using GSB_BM.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GSB_BM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly GSBContext _context;

        //public TokenController(ArosajeContext context)
        //{
        //    _context = context;
        //}

        private IConfiguration _config;
        public TokenController(IConfiguration config, GSBContext context)
        {
            _config = config;
            _context = context;

        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginRequest)
        {
            //your logic for login process
            //If login usrename and password are correct then proceed to generate token

            Utilisateur? user = _context.Utilisateurs.Where(U => U.Login.Equals(loginRequest.username) && U.Password.Equals(loginRequest.password)).FirstOrDefault();

            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);

            }
            return BadRequest();


        }
    }
}