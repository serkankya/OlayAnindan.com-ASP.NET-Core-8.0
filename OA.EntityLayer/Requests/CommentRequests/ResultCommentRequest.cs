namespace OA.EntityLayer.Requests.CommentRequests
{
	public class ResultCommentRequest
	{
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? MainTitle { get; set; }
        public string? CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
