namespace OA.EntityLayer.Requests.UserRequests
{
	public record InsertUserRequest(int RoleId, string Username, string PasswordHash, string Email, string Biography, string FullName, string ImageUrl);
}
