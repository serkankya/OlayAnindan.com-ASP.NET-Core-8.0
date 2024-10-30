namespace OA.EntityLayer.Requests.SocialMediaRequests
{
	public record InsertSocialMediaRequest(string Name, string Icon, string BiggerIcon, string SiteUrl, int Follower, string LeftBackgroundColor, string RightBackgroundColor);
}
