using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : GenericApiController<Article, InsertArticleRequest, UpdateArticleRequest>
	{
		readonly IArticleDal _articleDal;

		public ArticleController(IGenericRepository<Article, InsertArticleRequest, UpdateArticleRequest> repository, IArticleDal articleDal)
			: base(repository)
		{
			_articleDal = articleDal;
		}

		[HttpGet("GetResultArticles")]
		public async Task<IActionResult> GetResultArticles()
		{
			var values = await _articleDal.GetResultArticles();
			return Ok(values);
		}

		[HttpGet("GetResultArticle/{id}")]
		public async Task<IActionResult> GetResultArticleById(int id)
		{
			var value = await _articleDal.GetResultArticleById(id);
			return Ok(value);
		}
	}
}
