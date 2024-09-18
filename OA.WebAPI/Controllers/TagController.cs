using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.TagRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagController : GenericApiController<Tag, InsertTagRequest, UpdateTagRequest>
	{
		public TagController(IGenericRepository<Tag, InsertTagRequest, UpdateTagRequest> repository)
			: base(repository)
		{
		}
	}
}
