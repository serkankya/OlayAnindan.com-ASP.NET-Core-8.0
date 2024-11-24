using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.SubscriberRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscriberController : GenericApiController<Subscriber, InsertSubscriberRequest, UpdateSubscriberRequest>
	{
        public SubscriberController(IGenericRepository<Subscriber, InsertSubscriberRequest, UpdateSubscriberRequest> repository)
            : base(repository)
        {
            
        }
    }
}
