using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.MediaRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MediaController : GenericApiController<Media, InsertMediaRequest, UpdateMediaRequest>
	{
		public MediaController(IGenericRepository<Media, InsertMediaRequest, UpdateMediaRequest> repository)
			: base(repository)
		{
		}
	}
}
