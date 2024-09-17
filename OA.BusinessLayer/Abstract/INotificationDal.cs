using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.NotificationRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface INotificationDal : IGenericRepository<Notification, InsertNotificationRequest, UpdateNotificationRequest>
	{
	}
}
