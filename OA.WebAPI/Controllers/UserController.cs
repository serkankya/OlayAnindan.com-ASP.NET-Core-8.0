﻿using Microsoft.AspNetCore.Authorization;
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
		public UserController(IGenericRepository<User, InsertUserRequest, UpdateUserRequest> repository, IUserDal userDal)
			: base(repository)
		{
		}

		[Authorize]
		[HttpGet("SecureEndpoint")]
		public IActionResult SecureEndpoint()
		{
			return Ok("This endpoint is accessible only to authenticated users.");
		}
	}
}
