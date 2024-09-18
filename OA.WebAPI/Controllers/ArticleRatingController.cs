using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRatingRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleRatingController : GenericApiController<ArticleRating, InsertArticleRatingRequest, UpdateArticleRatingRequest>
	{
		public ArticleRatingController(IGenericRepository<ArticleRating, InsertArticleRatingRequest, UpdateArticleRatingRequest> repository)
			: base(repository)
		{
		}
	}
}
