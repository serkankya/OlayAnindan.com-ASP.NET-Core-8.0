using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CategoryRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : GenericApiController<Category, InsertCategoryRequest, UpdateCategoryRequest>
	{
		public CategoryController(IGenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest> repository)
			: base(repository)
		{
		}
	}
}
