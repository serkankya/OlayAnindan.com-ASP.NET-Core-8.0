namespace OA.EntityLayer.Requests.ArticleRatingRequests
{
	public record UpdateArticleRatingRequest(int RatingId, int ArticleId, int UserId, Int16 RatingValue, bool Status);
}
