﻿namespace OA.EntityLayer.Requests.UserRequests
{
	public record UpdateUserRequest(int UserId, int RoleId, string Username, string PasswordHash, string Email, string Biography, string FullName, string ImageUrl, DateTime UpdatedAt, bool Status);
}
