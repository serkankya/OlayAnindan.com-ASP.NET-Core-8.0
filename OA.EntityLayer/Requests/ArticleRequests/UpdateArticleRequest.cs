namespace OA.EntityLayer.Requests.ArticleRequests
{
	public record UpdateArticleRequest(int ArticleId, int UserId, int CategoryId, string MainTitle, string MainText, string FirstTitle, string FirstText, string SecondTitle, string SecondText, string Summary, bool IsFeatured, DateTime UpdatedAt, bool Status);
}
