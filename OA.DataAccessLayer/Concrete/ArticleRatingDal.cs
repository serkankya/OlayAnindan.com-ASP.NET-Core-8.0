using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRatingRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class ArticleRatingDal : GenericRepository<ArticleRating, InsertArticleRatingRequest, UpdateArticleRatingRequest>, IArticleRatingDal
	{
		public ArticleRatingDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<ArticleRating, InsertArticleRatingRequest, UpdateArticleRatingRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
