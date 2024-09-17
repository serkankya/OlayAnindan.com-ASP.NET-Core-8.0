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
		public ArticleDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
