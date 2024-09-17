using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.UserRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IUserDal : IGenericRepository<User, InsertUserRequest, UpdateUserRequest>
	{
	}
}
