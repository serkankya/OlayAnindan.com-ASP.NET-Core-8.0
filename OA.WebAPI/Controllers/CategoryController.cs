using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CategoryRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : GenericApiController<Category, InsertCategoryRequest, UpdateCategoryRequest>
	{
		readonly ICategoryDal _categoryDal;

		public CategoryController(IGenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest> repository, ICategoryDal categoryDal)
			: base(repository)
		{
			_categoryDal = categoryDal;
		}

		[HttpPut("ActivateCategory/{id}")]
		public async Task<IActionResult> ActivateCategory(int id)
		{
			bool isActivated = await _categoryDal.ActivateCategory(id);

			if (isActivated == false)
			{
				return BadRequest("Activation failed.");
			}

			return Ok("Comment activated successfully.");
		}
	}
}
