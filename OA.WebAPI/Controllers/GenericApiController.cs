using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;

namespace OA.WebAPI.Controllers
{
	public class GenericApiController<T, InsertTRequest, UpdateTRequest> : ControllerBase
		where T : class, new()
		where InsertTRequest : class
		where UpdateTRequest : class
	{
		private readonly IGenericRepository<T, InsertTRequest, UpdateTRequest> _repository;

		public GenericApiController(IGenericRepository<T, InsertTRequest, UpdateTRequest> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var values = await _repository.GetAllAsync();
			return Ok(values);
		}

		[HttpGet("GetActives")]
		public async Task<IActionResult> GetActives()
		{
			var values = await _repository.GetActivesAsync();
			return Ok(values);
		}

		[HttpPost("Insert")]
		public async Task<IActionResult> Insert([FromBody] InsertTRequest insertTRequest)
		{
			bool isInserted = await _repository.InsertAsync(insertTRequest);

			if (!isInserted)
			{
				return BadRequest("Insert failed.");
			}
			return Ok("Entity inserted successfully.");
		}

		[HttpPut("Update")]
		public async Task<IActionResult> Update([FromBody] UpdateTRequest updateTRequest)
		{
			bool isUpdated = await _repository.UpdateAsync(updateTRequest);

			if (!isUpdated)
			{
				return BadRequest("Update failed.");
			}
			return Ok("Entity updated successfully.");
		}

		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			bool isDeleted = await _repository.DeleteAsync(id);

			if (!isDeleted)
			{
				return BadRequest("Delete failed!");
			}

			return Ok("Entity deleted successfully.");
		}

		[HttpPut("Remove/{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			bool isRemoved = await _repository.RemoveAsync(id);

			if (!isRemoved)
			{
				return BadRequest("Remove failed");
			}

			return Ok("Entity removed successfully");
		}

		[HttpGet("Get/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			T value = await _repository.GetByIdAsync(id);

			if (value == null)
			{
				return NotFound("Entity not found.");
			}

			return Ok(value);
		}
	}
}
