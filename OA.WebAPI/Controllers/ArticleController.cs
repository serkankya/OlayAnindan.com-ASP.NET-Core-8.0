using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;
using OA.EntityLayer.Requests.TagRequests;

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
            await UpdateViewCountById(id);
            return Ok(value);
        }

        //.will be updated
        [HttpPost("UpdateViewCount/{id}")]
        public async Task<IActionResult> UpdateViewCountById(int id)
        {
            bool isUpdated = await _articleDal.UpdateViewCountById(id);

			if (isUpdated == false)
			{
				return BadRequest("Update failed.");
			}

			return Ok("View count updated successfully.");
		}

        [HttpPost("InsertTransaction")]
        public async Task<IActionResult> InsertTransaction(InsertArticleTransactionRequest insertArticleTransactionRequest)
        {
            bool isInserted = await _articleDal.InsertTransaction(insertArticleTransactionRequest);

            if (!isInserted)
            {
                return BadRequest("Insert failed.");
            }
            return Ok("Entity inserted successfully.");
        }

        [HttpGet("GetFeaturedNews")]
        public async Task<IActionResult> GetFeaturedNews()
        {
            var values = await _articleDal.GetFeaturedNews();
            return Ok(values);
        }

        [HttpGet("GetMainNews")]
        public async Task<IActionResult> GetMainNews()
        {
            var values = await _articleDal.GetMainNewsHighlights();
            return Ok(values);
        }

        [HttpGet("GetLatestNews")]
        public async Task<IActionResult> GetLatestNews()
        {
            var values = await _articleDal.GetLatestNews();
            return Ok(values);
        }

        [HttpGet("GetFilteredNewsByCategoryAndDate")]
        public async Task<IActionResult> GetFilteredNewsByCategoryAndDate(int categoryId, bool dateOption)
        {
            var values = await _articleDal.GetFilteredNewsByCategoryAndDate(categoryId, dateOption);
            return Ok(values);
        }

        [HttpGet("GetFilteredNewsByTag")]
        public async Task<IActionResult> GetFilteredNewsByTag(int tagId)
        {
            var values = await _articleDal.GetFilteredNewsByTag(tagId);
            return Ok(values);
        }

        [HttpGet("SearchArticles")]
        public async Task<IActionResult> SearchArticles(string keyWord)
        {
            var values = await _articleDal.SearchArticles(keyWord);
            return Ok(values);
        }
    }
}
