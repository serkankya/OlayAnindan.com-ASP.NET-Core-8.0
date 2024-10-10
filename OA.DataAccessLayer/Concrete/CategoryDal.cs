using Dapper;
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
		readonly IDapperContext _dapperContext;

		public CategoryDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest>> logger)
	   : base(sqlToolsProvider, dapperContext, logger)
		{
			_dapperContext = dapperContext;
		}

		public async Task<bool> ActivateCategory(int id)
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string activateQuery = "UPDATE Categories SET Status = 1 WHERE CategoryId = @categoryId";

				var parameters = new DynamicParameters();
				parameters.Add("@categoryId", id);

				int affectedRows = await connection.ExecuteAsync(activateQuery, parameters);

				if (affectedRows > 0)
				{
					return true;
				}

				return false;
			}
		}
	}
}
