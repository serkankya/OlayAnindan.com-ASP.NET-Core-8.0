namespace OA.EntityLayer.Requests.ArticleRatingRequests
{
	public record InsertArticleRatingRequest(int ArticleId, int UserId, Int16 RatingValue);
}
