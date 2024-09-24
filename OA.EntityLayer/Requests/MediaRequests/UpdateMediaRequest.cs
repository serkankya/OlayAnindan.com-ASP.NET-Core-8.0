namespace OA.EntityLayer.Requests.MediaRequests
{
	public record UpdateMediaRequest(int MediaId, int ArticleId, string MainMediaPath, string MainMediaType, string FirstMediaPath, string FirstMediaType, string SecondMediaPath, string SecondMediaType, DateTime UploadedAt, bool Status);
}
