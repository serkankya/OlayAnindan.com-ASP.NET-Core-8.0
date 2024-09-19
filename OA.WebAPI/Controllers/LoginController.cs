using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.EntityLayer.Requests.LoginRequests;
using OA.WebAPI.JwtTools;

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
	}
}
