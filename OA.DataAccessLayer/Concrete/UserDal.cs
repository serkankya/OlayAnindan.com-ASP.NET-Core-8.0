using Dapper;
using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.LoginRequests;
using OA.EntityLayer.Requests.UserRequests;
using System.Data;

namespace OA.DataAccessLayer.Concrete
{
    public class UserDal : GenericRepository<User, InsertUserRequest, UpdateUserRequest>, IUserDal
	{
		readonly IDapperContext _dapperContext;

		public UserDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<User, InsertUserRequest, UpdateUserRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{
			_dapperContext = dapperContext;
		}

		public async Task<List<ResultUserRequest>> GetUserDetails()
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string getQuery = "SELECT u.*, r.RoleName FROM Users u INNER JOIN Roles r ON u.RoleId = r.RoleId";

				var values = await connection.QueryAsync<ResultUserRequest>(getQuery);
				return values.ToList();
			}
		}
	}
}
