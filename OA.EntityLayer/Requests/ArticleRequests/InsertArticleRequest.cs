namespace OA.EntityLayer.Requests.ArticleRequests
{
	public record InsertArticleRequest(int UserId, int CategoryId, string Title, string ContentText, string Summary, bool IsFeatured);
}
