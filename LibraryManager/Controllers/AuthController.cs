using AutoMapper;
using LibraryManager.Models.Configurations.Settings;
using LibraryManager.Models.Domains;
using LibraryManager.Models.ViewModels.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMapper Mapper { get; }
        private UserManager<User> UserService { get; }
        private JwtSecret JwtSecret { get; }

        public AuthController(IMapper mapper, UserManager<User> userService, JwtSecret jwtSecret)
        {
            Mapper = mapper;
            UserService = userService;
            JwtSecret = jwtSecret;
        }

        [HttpPost]
        public async Task<ActionResult<Token>> Login(Login entry)
        {
            User user = await UserService.FindByNameAsync(entry.UserName);

            if (user == null)
            {
                return BadRequest();
            }

            if (!await UserService.CheckPasswordAsync(user, entry.Password))
            {
                return BadRequest();
            }

            IList<string> roles = await UserService.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, string.Format("{0} {1}", user.FirstName, user.LastName)),
                new Claim(ClaimTypes.Role, string.Join(", ", roles))
            };

            SymmetricSecurityKey symmetric = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret.Key));

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: JwtSecret.Issuer,
                audience: JwtSecret.Audience,
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(symmetric, SecurityAlgorithms.HmacSha256)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            Token token = new Token()
            {
                HashKey = handler.WriteToken(jwt),
                ExpireTime = jwt.ValidTo.ToString("MM/dd/yyyy hh:mm tt")
            };

            return Ok(token);
        }
    }
}
