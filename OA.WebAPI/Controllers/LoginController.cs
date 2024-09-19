using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.EntityLayer.Requests.LoginRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		readonly ILoginDal _loginDal;

		public LoginController(ILoginDal loginDal)
		{
			_loginDal = loginDal;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginRequest loginUserRequest)
		{
			int userId = await _loginDal.Login(loginUserRequest);

			if (userId > 0)
			{
				return Ok(new { Message = "Successful login process.", UserId = userId });
			}
			else
			{
				return NotFound("Invalid username or password.");
			}
		}
	}
}
