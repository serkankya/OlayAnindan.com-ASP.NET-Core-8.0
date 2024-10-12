using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.UserRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : GenericApiController<User, InsertUserRequest, UpdateUserRequest>
	{
		readonly IUserDal _userDal;

		public UserController(IGenericRepository<User, InsertUserRequest, UpdateUserRequest> repository, IUserDal userDal)
			: base(repository)
		{
			_userDal = userDal;
		}

		[Authorize]
		[HttpGet("SecureEndpoint")]
		public IActionResult SecureEndpoint()
		{
			return Ok("This endpoint is accessible only to authenticated users.");
		}

		[HttpGet("GetUserDetails")]
		public async Task<IActionResult> GetUserDetails()
		{
			var values = await _userDal.GetUserDetails();
			return Ok(values);
		}

		[HttpGet("GetBlockedUsers")]
		public async Task<IActionResult> GetBlockedUsers()
		{
			var values = await _userDal.GetBlockedUsers();
			return Ok(values);
		}

		[HttpGet("GetUser/{id}")]
		public async Task<IActionResult> GetUserById(int id)
		{
			var values = await _userDal.GetUserById(id);
			return Ok(values);
		}
	}
}
