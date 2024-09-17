namespace OA.EntityLayer.Requests.ArticleRequests
{
	public record UpdateArticleRequest(int ArticleId, int UserId, int CategoryId, string Title, string ContentText, string Summary, bool IsFeatured, DateTime UpdatedAt, bool Status);
}
