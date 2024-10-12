namespace OA.EntityLayer.Requests.UserRequests
{
	public class ResultUserRequest
	{
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Biography { get; set; }
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public string? Status { get; set; }
        public string? IsBlocked { get; set; }
        public string? LastLogin { get; set; }
    }
}
