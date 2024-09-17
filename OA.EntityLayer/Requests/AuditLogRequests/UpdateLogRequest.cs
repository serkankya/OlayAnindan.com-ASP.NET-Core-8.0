namespace OA.EntityLayer.Requests.AuditLogRequests
{
	public record UpdateLogRequest(int LogId, int UserId, string Action, bool Status);
}
