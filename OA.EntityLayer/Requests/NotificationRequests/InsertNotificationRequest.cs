using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.NotificationRequests
{
	public record InsertNotificationRequest(int UserId, string Message);
}
