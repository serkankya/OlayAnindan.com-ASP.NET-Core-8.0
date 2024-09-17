using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.RoleRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BusinessLayer.Abstract
{
	public interface IRoleDal : IGenericRepository<Role, InsertRoleRequest, UpdateRoleRequest>
	{
	}
}
