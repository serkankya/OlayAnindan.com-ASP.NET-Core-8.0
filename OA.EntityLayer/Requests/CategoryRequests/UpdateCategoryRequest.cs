namespace OA.EntityLayer.Requests.CategoryRequests
{
	public record UpdateCategoryRequest(int CategoryId, string CategoryName, string Description, string CoverImage, DateTime UpdatedDate, bool Status);
}
