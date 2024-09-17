using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.UserRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class UserDal : GenericRepository<User, InsertUserRequest, UpdateUserRequest>, IUserDal
	{
		public UserDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<User, InsertUserRequest, UpdateUserRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
