using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.SocialMediaRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : GenericApiController<SocialMedia, InsertSocialMediaRequest, UpdateSocialMediaRequest>
	{
		public SocialMediaController(IGenericRepository<SocialMedia, InsertSocialMediaRequest, UpdateSocialMediaRequest> repository)
			: base(repository)
		{

		}
	}
}
