namespace OA.EntityLayer.Requests.AuditLogRequests
{
	public record InsertLogRequest(int UserId, string Action);
}
