using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.RoleRequests;

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

		[HttpGet("GetActives")]
		public async Task<IActionResult> GetActives()
		{
			var values = await _roleDal.GetActivesAsync();
			return Ok(values);
		}

		[HttpPost("InsertRole")]
		public async Task<IActionResult> InsertRole(InsertRoleRequest insertRoleRequest)
		{
			Role insertRole = new Role
			{
				RoleName = insertRoleRequest.RoleName,
				Description = insertRoleRequest.Description
			};

			await _roleDal.InsertAsync(insertRole);
			return Ok("Role inserted successfully.");
		}

		[HttpPut("UpdateRole")]
		public async Task<IActionResult> UpdateRole(UpdateRoleRequest updateRoleRequest)
		{
			Role updateRole = new Role
			{
				RoleId = updateRoleRequest.RoleId,
				RoleName = updateRoleRequest.RoleName,
				Description = updateRoleRequest.Description
			};

			await _roleDal.UpdateAsync(updateRole);
			return Ok("Role updated successfully.");
		}

		[HttpDelete("DeleteRole/{id}")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			await _roleDal.DeleteAsync(id);
			return Ok("Role deleted successfully.");
		}

		[HttpPut("RemoveRole/{id}")]
		public async Task<IActionResult> RemoveRole(int id)
		{
			await _roleDal.RemoveAsync(id);
			return Ok("Role removed successfully.");
		}

		[HttpGet("GetRole/{id}")]
		public async Task<IActionResult> GetRoleById(int id)
		{
			var value = await _roleDal.GetByIdAsync(id);
			return Ok(value);
		}
	}
}
