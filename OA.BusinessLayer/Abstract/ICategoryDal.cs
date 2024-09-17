using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CategoryRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface ICategoryDal : IGenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest>
	{
	}
}
