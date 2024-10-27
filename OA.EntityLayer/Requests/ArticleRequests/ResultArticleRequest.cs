namespace OA.EntityLayer.Requests.ArticleRequests
{
	public class ResultArticleRequest
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? MainTitle { get; set; }
        public string? MainText { get; set; }
        public string? FirstTitle { get; set; }
        public string? FirstText { get; set; }
        public string? SecondTitle { get; set; }
        public string? SecondText { get; set; }
        public string? Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public int ViewCount { get; set; }
        public bool IsMainNews { get; set; }
        public bool IsFeatured { get; set; }
        public string? MainMediaPath { get; set; }
        public string? MainMediaType { get; set; }
        public string? FirstMediaPath { get; set; }
        public string? FirstMediaType { get; set; }
        public string? SecondMediaPath { get; set; }
        public string? SecondMediaType { get; set; }
        public string? ImageUrl { get; set; } //User
        public List<string>? Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Status { get; set; }
    }
}
