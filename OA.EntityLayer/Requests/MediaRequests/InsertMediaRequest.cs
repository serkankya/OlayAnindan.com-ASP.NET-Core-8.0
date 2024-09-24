namespace OA.EntityLayer.Requests.MediaRequests
{
	public record InsertMediaRequest(int ArticleId, string MainMediaPath, string MainMediaType, string FirstMediaPath, string FirstMediaType, string SecondMediaPath, string SecondMediaType);
}
