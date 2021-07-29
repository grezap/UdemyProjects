using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.ServiceContracts;
using MvcTaskManager.ViewModels;
using System.Threading.Tasks;

namespace MvcTaskManager.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    public class AccountController : Controller
    {
        public IUsersService _usersService;

        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("api/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginViewModel loginViewModel)
        {
            var user = await _usersService.Authenticate(loginViewModel);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
