using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.RoleRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IRoleDal : IGenericRepository<Role, InsertRoleRequest, UpdateRoleRequest>
	{
	} 
}
