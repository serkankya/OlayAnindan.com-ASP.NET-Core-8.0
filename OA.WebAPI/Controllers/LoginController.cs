using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.EntityLayer.Requests.LoginRequests;
using OA.WebAPI.JwtTools;
using System.IdentityModel.Tokens.Jwt;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		readonly ILoginDal _loginDal;
		readonly IConfiguration _configuration;

		public LoginController(ILoginDal loginDal, IConfiguration configuration_)
		{
			_loginDal = loginDal;
			_configuration = configuration_;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginRequest loginUserRequest)
		{
			int userId = await _loginDal.Login(loginUserRequest);

			if (userId > 0)
			{
				GenerateJwtToken generateJwtToken = new(_configuration);
				var token = generateJwtToken.Generate(userId);

				return Ok(new { Message = "Successful login process.", Token = token });
			}
			else
			{
				return NotFound("Invalid username or password.");
			}
		}

		[HttpGet("TestToken")]
		public IActionResult TestToken()
		{
			var token = new GenerateJwtToken(_configuration).Generate(1);
			return Ok(new { Token = token });
		}

        [HttpPost("CheckOnline")]
        public IActionResult CheckOnline([FromHeader] string token)
        {
            bool isOnline = IsUserOnline(token);
            if (isOnline)
            {
                return Ok(new { Message = "User is online." });
            }
            else
            {
                return Unauthorized(new { Message = "User is offline or token is invalid." });
            }
        }

        private bool IsUserOnline(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var expiryDate = jwtToken.ValidTo;
            return expiryDate > DateTime.UtcNow;
        }

    }
}
