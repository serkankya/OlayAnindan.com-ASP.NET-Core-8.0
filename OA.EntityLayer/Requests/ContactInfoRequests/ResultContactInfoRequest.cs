namespace OA.EntityLayer.Requests.ContactInfoRequests
{
    public class ResultContactInfoRequest
    {
        public int ContactInfoId { get; set; }
        public string? Info { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
