namespace OA.EntityLayer.Requests.MediaRequests
{
	public record UpdateMediaRequest(int MediaId, int ArticleId, string FilePath, string FileType, string AltText, bool Status);
}
