using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ContactMessageRequests;

namespace OA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : GenericApiController<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest>
    {
        public ContactController(IGenericRepository<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest> repository)
            : base(repository)
        {
        }
    }
}
