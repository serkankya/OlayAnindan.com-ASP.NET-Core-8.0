using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.NotificationRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : GenericApiController<Notification, InsertNotificationRequest, UpdateNotificationRequest>
	{
		public NotificationController(IGenericRepository<Notification, InsertNotificationRequest, UpdateNotificationRequest> repository)
			: base(repository)
		{
		}
	}
}
