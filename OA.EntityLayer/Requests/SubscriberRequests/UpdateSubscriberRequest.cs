namespace OA.EntityLayer.Requests.SubscriberRequests
{
	public record UpdateSubscriberRequest(int SubscriberId, string Email, DateTime RemovedAt, bool Status);
}
