using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ContactInfoRequests;

namespace OA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : GenericApiController<ContactInfo, InsertContactInfoRequest, UpdateContactInfoRequest>
    {
        public ContactInfoController(IGenericRepository<ContactInfo, InsertContactInfoRequest, UpdateContactInfoRequest> repository)
            : base(repository)
        {

        }
    }
}
