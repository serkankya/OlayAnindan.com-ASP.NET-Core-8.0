namespace OA.EntityLayer.Requests.AdRequests
{
	public record UpdateAdRequest(int AdsId, string CompanyName, string CompanyWebsite, string AdsUrl, string ImageUrl, DateTime UpdatedAt, bool Status);
}
