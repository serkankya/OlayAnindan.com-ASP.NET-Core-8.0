namespace OA.EntityLayer.Requests.MediaRequests
{
	public record InsertMediaRequest(int ArticleId, string FilePath, string FileType, string AltText);
}
