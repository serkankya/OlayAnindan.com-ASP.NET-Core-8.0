using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.AuditLogRequests
{
	public record InsertLogRequest(int UserId, string Action);
}
