namespace OA.EntityLayer.Requests.ArticleTagRequests
{
	public class ResultArticleTagRequest
	{
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public bool Status { get; set; }
    }
}
