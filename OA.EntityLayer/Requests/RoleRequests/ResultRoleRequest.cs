namespace OA.EntityLayer.Requests.RoleRequests
{
	public class ResultRoleRequest
	{
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
