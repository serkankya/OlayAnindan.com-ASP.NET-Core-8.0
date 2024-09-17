namespace OA.EntityLayer.Requests.NotificationRequests
{
	public record UpdateNotificationRequest(int NotificationId, int UserId, string Message, bool IsRead, bool Status);
}
