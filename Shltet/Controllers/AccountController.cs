using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shltet.DTO;
using Shltet.Modles;
using Shltet.Services.IServices;

namespace Shltet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            IAccountService accountService,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _accountService = accountService;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(ApplicationUserDto userDto)
        {
            var result = await _accountService.RegisterAsync(userDto);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userVm)
        {
            var result = await _accountService.LoginAsync(userVm);
            return Ok(result);
        }


    }
}
