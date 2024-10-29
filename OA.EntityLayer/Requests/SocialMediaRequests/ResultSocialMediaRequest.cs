namespace OA.EntityLayer.Requests.SocialMediaRequests
{
	public class ResultSocialMediaRequest
	{
        public int SocialMediaId { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? SiteUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
