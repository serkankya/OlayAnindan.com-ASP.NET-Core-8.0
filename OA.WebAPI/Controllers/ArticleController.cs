using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : GenericApiController<Article, InsertArticleRequest, UpdateArticleRequest>
	{
		public ArticleController(IGenericRepository<Article, InsertArticleRequest, UpdateArticleRequest> repository)
			: base(repository)
		{
		}
	}
}
