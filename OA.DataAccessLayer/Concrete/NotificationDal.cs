using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.NotificationRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class NotificationDal : GenericRepository<Notification, InsertNotificationRequest, UpdateNotificationRequest>, INotificationDal
	{
		public NotificationDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Notification, InsertNotificationRequest, UpdateNotificationRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
