namespace OA.EntityLayer.Requests.SocialMediaRequests
{
	public record UpdateSocialMediaRequest(int SocialMediaId, string Name, string Icon, string BiggerIcon, string SiteUrl, int Follower, string LeftBackgroundColor, string RightBackgroundColor);
}
