using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.AdRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdController : GenericApiController<Ad, InsertAdRequest, UpdateAdRequest>
	{
        public AdController(IGenericRepository<Ad, InsertAdRequest, UpdateAdRequest> repository)
            : base(repository)
        {
            
        }
    }
}
