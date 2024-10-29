namespace OA.EntityLayer.Requests.ContactInfoRequests
{
    public record UpdateContactInfoRequest(int ContactInfoId, string Info, string Address, string Email, string PhoneNumber, string Status);
}
