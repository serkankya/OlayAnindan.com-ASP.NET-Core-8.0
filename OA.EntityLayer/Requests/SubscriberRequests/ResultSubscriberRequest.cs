namespace OA.EntityLayer.Requests.SubscriberRequests
{
	public class ResultSubscriberRequest
	{
        public int SubscriberId { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime RemovedAt { get; set; }
        public bool Status { get; set; }
    }
}
