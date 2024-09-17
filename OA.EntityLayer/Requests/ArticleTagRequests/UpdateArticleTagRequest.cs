namespace OA.EntityLayer.Requests.ArticleTagRequests
{
	public record UpdateArticleTagRequest(int ArticleId, int TagId, bool Status);
}
