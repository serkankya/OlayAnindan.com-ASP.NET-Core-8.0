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

		public async Task<List<ResultUserRequest>> GetBlockedUsers()
		{
			using (var connection  = _dapperContext.GetConnection())
			{
				string getBlockedQuery = "SELECT u.*, r.RoleName FROM Users u INNER JOIN Roles r ON u.RoleId = r.RoleId WHERE u.IsBlocked = 1";

				var values = await connection.QueryAsync<ResultUserRequest>(getBlockedQuery);
				return values.ToList();
			}
		}

		public async Task<ResultUserRequest> GetUserById(int id)
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string getUserQuery = "SELECT u.*, r.RoleName FROM Users u INNER JOIN Roles r ON u.RoleId = r.RoleId WHERE UserId = @userId";

				var parameters = new DynamicParameters();
				parameters.Add("@userId", id);

				var value = await connection.QueryFirstOrDefaultAsync<ResultUserRequest>(getUserQuery,parameters);

				if(value == null)
				{
					return new ResultUserRequest
					{
						UserId = 0,
						Username = "User not found."
					};
				}

				return value;
			}
		}
	}
}
