using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CategoryRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class CategoryDal : GenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest>, ICategoryDal
	{
		public CategoryDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest>> logger)
	   : base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
