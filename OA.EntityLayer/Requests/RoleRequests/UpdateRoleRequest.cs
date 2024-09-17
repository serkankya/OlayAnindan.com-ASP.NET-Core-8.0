using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.RoleRequests
{
	public record UpdateRoleRequest(int RoleId, string RoleName, string Description, bool Status);
}
