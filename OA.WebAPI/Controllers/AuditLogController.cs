using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.AuditLogRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuditLogController : GenericApiController<AuditLog, InsertLogRequest, UpdateLogRequest>
	{
		public AuditLogController(IGenericRepository<AuditLog, InsertLogRequest, UpdateLogRequest> repository)
			: base(repository)
		{
		}
	}
}
