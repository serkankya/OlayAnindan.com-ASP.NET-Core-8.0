using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleTagRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleTagController : GenericApiController<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>
	{
		public ArticleTagController(IGenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest> repository)
			: base(repository)
		{
		}
	}
}
