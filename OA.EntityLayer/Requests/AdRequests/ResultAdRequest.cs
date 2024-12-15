namespace OA.EntityLayer.Requests.AdRequests
{
	public class ResultAdRequest
	{
		public int AdsId { get; set; }
		public string? CompanyName { get; set; }
		public string? CompanyWebsite { get; set; }
		public string? AdsUrl { get; set; }
		public string? ImageUrl { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Status { get; set; }
	}
}
