namespace OA.EntityLayer.Requests.ContactMessageRequests
{
    public class ResultContactMessageRequest
    {
        public int ContactMessageId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
        public bool Status { get; set; }
    }
}
