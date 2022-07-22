using AutoMapper;
using LibraryManager.Models.Domains;
using LibraryManager.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> UserService { get; }
        private IMapper Mapper { get; }

        public UserController(UserManager<User> userService, IMapper mapper)
        {
            UserService = userService;
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<DetailsUser>> Register(CreateUser entry)
        {
            /*
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errors  = (ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));
                return BadRequest(errors);
            }
            */

            IdentityResult result = await UserService.CreateAsync(Mapper.Map<User>(entry), entry.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(error => error.Description));
            }

            User user = await UserService.FindByNameAsync(entry.UserName);

            //await UserService.AddClaimAsync(user, new System.Security.Claims.Claim("FirstName" , "Rashin"))

            return Ok(Mapper.Map<DetailsUser>(user));
        }
    }
}
