namespace OA.EntityLayer.Requests.CommentRequests
{
	public record InsertCommentRequest(int ArticleId, int UserId, string CommentText, DateTime CreatedDate);
}
