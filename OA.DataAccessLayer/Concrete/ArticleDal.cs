using Dapper;
using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class ArticleDal : GenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>, IArticleDal
	{
		readonly IDapperContext _dapperContext;

		public ArticleDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{
			_dapperContext = dapperContext;
		}

		public async Task<ResultArticleRequest> GetResultArticleById(int articleId)
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForArticle = "SELECT * FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId WHERE a.ArticleId = @articleId AND (a.Status = 1 AND m.Status = 1)";

				var parameters = new DynamicParameters();
				parameters.Add("@articleId", articleId);

				var value = await connection.QueryFirstOrDefaultAsync<ResultArticleRequest>(queryForArticle, parameters);

				if(value == null)
				{
					return new ResultArticleRequest
					{
						ArticleId = 0,
						Title = "Article not found or inactive!"
					};
				}

				return value;
			}
		}

		public async Task<List<ResultArticleRequest>> GetResultArticles()
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForArticles = "SELECT * FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId WHERE a.Status = 1 AND m.Status = 1";

				var values = await connection.QueryAsync<ResultArticleRequest>(queryForArticles);
				return values.ToList();
			}
		}
	}
}
