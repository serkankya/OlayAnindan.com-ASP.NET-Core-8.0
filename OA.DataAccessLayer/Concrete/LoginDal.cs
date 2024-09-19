using Dapper;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.EntityLayer.Requests.LoginRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class LoginDal : ILoginDal
	{
		readonly IDapperContext _dapperContext;

		public LoginDal(IDapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		public async Task<int> Login(LoginRequest loginRequest)
		{
			try
			{
				string loginQuery = "SELECT UserId FROM Users WHERE (Username = @username AND PasswordHash = @password) AND Status = 1";

				var parameters = new DynamicParameters();
				parameters.Add("@username", loginRequest.Username);
				parameters.Add("@password", loginRequest.PasswordHash);

				using (var connection = _dapperContext.GetConnection())
				{
					int userId = await connection.QueryFirstOrDefaultAsync<int>(loginQuery, parameters);

					if (userId > 0)
					{
						string updateLastLoginQuery = "UPDATE Users SET LastLogin = @lastLogin WHERE UserId = @userId";

						var parametersForUpdate = new DynamicParameters();
						parametersForUpdate.Add("@lastLogin", DateTime.Now);
						parametersForUpdate.Add("@userId", userId);

						await connection.ExecuteAsync(updateLastLoginQuery, parametersForUpdate);

						return userId;
					}

					return 0;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("An error occured while login proccess: ", ex);
			}
		}
	}
}
