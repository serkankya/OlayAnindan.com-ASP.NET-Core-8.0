namespace OA.EntityLayer.Requests.CategoryRequests
{
	public record UpdateCategoryRequest(int CategoryId, string CategoryName, string Description, DateTime UpdatedDate, bool Status);
}
