using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersMicroservice.Core.DTO;
using UsersMicroservice.Core.ServiceContracts;

namespace UsersMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        //Endpoint for user registration use case
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            //check for invalid register  data
            if (request == null)
            {
                return BadRequest("invalid Registration Data");
            }
            AuthenticationResponse? response = await _userService.Register(request);
            if (response == null || response.Success == false)
            {
                return BadRequest("Failed to register the New user");

            }
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("invalid Login Credentials Data Provided");
            }
            AuthenticationResponse? response = await _userService.Login(request);
            if (response == null || response.Success == false)
            {
                return Unauthorized("User Doesn't have the access");

            }
            return Ok(response);

        }

    }
}
