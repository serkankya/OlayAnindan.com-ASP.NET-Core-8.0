using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.AuditLogRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IAuditLogDal : IGenericRepository<AuditLog, InsertLogRequest, UpdateLogRequest>
	{
	}
}
