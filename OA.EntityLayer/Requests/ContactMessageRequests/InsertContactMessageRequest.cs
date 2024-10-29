namespace OA.EntityLayer.Requests.ContactMessageRequests
{
    public record InsertContactMessageRequest(string FullName, string Email, string Subject, string Message);
}
