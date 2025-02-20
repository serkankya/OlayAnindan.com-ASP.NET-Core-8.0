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
		readonly IUserDal _userDal;

		public LoginController(ILoginDal loginDal, IConfiguration configuration_, IUserDal userDal)
		{
			_loginDal = loginDal;
			_configuration = configuration_;
			_userDal = userDal;
		}

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginUserRequest)
        {
            int userId = await _loginDal.Login(loginUserRequest);

            if (userId > 0)
            {
                var userDetails = await _userDal.GetUserById(userId);
                int roleId = userDetails.RoleId;  // Kullanıcının rolünü alıyoruz

                var jwtService = new GenerateJwtToken(_configuration);
                string token = jwtService.Generate(userId, roleId); // Token üretirken roleId ekledik

                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

  //      [HttpGet("TestToken")]
		//public IActionResult TestToken()
		//{
		//	var token = new GenerateJwtToken(_configuration).Generate(1);
		//	return Ok(new { Token = token });
		//}

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
