using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.AuditLogRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class AuditLogDal : GenericRepository<AuditLog, InsertLogRequest, UpdateLogRequest>, IAuditLogDal
	{
		public AuditLogDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<AuditLog, InsertLogRequest, UpdateLogRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
