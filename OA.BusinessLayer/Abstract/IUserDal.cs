using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.LoginRequests;
using OA.EntityLayer.Requests.UserRequests;

namespace OA.BusinessLayer.Abstract
{
    public interface IUserDal : IGenericRepository<User, InsertUserRequest, UpdateUserRequest>
	{
		Task<List<ResultUserRequest>> GetUserDetails();
		Task<List<ResultUserRequest>> GetBlockedUsers();
		Task<ResultUserRequest> GetUserById(int id);
	}
}
