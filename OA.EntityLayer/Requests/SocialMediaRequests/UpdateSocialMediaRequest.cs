namespace OA.EntityLayer.Requests.SocialMediaRequests
{
	public record UpdateSocialMediaRequest(int SocialMediaId, string Name, string Icon, string SiteUrl);
}
