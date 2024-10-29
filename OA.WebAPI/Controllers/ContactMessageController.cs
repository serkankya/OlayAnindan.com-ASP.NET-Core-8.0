using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ContactMessageRequests;

namespace OA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageController : GenericApiController<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest>
    {
        public ContactMessageController(IGenericRepository<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest> repository)
            : base(repository)
        {
        }
    }
}
