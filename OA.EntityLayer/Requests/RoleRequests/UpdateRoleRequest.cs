namespace OA.EntityLayer.Requests.RoleRequests
{
	public record UpdateRoleRequest(int RoleId, string RoleName, string Description, bool Status);
}
