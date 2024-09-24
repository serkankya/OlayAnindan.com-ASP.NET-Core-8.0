using Dapper;
using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleTagRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class ArticleTagDal : GenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>, IArticleTagDal
	{
		readonly IDapperContext _dapperContext;

		public ArticleTagDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{
			_dapperContext = dapperContext;
		}

		public async Task<List<ResultArticleTagRequest>> GetResultArticleTagsById(int articleId)
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForArticleTags = "SELECT art.ArticleId, art.TagId, TagName FROM ArticleTags art INNER JOIN Tags t ON art.TagId = t.TagId WHERE art.ArticleId = @articleId AND (art.Status = 1 AND t.Status = 1)";

				var parameters = new DynamicParameters();
				parameters.Add("@articleId", articleId);

				var values = await connection.QueryAsync<ResultArticleTagRequest>(queryForArticleTags, parameters);

				return values.ToList();
			}
		}

		public async Task<List<ResultArticleTagRequest>> GetResultArticleTags()
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForArticleTags = "SELECT art.ArticleId, art.TagId, t.TagName,art.Status FROM ArticleTags art INNER JOIN Tags t ON art.TagId = t.TagId WHERE art.Status = 1 AND t.Status = 1";

				var values = await connection.QueryAsync<ResultArticleTagRequest>(queryForArticleTags);
				return values.ToList();
			}
		}
	}
}
