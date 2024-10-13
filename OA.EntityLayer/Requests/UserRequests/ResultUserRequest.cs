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
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Status { get; set; }
        public bool? IsBlocked { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
