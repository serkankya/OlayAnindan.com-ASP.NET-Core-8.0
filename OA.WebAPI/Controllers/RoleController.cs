using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		readonly IRoleDal _roleDal;

        public RoleController(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var values = await _roleDal.GetAllAsync();
			return Ok(values);
		}
    }
}
