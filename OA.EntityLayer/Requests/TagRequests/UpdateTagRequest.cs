namespace OA.EntityLayer.Requests.TagRequests
{
	public record UpdateTagRequest(int TagId, string TagName, bool Status);
}
