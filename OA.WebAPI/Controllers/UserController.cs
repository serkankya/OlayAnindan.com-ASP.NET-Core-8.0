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
	}
}
