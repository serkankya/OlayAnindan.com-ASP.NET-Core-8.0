using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleTagRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleTagController : GenericApiController<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>
	{
		readonly IArticleTagDal _articleTagDal;

		public ArticleTagController(IGenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest> repository, IArticleTagDal articleTagDal)
			: base(repository)
		{
			_articleTagDal = articleTagDal;
		}

		[HttpGet("GetResultArticleTags")]
		public async Task<IActionResult> GetResultArticleTags()
		{
			var values = await _articleTagDal.GetResultArticleTags();
			return Ok(values);
		}

		[HttpGet("GetResultArticleTags/{id}")]
		public async Task<IActionResult> GetResultArticleTagsById(int id)
		{
			var value = await _articleTagDal.GetResultArticleTagsById(id);
			return Ok(value);
		}
	}
}
