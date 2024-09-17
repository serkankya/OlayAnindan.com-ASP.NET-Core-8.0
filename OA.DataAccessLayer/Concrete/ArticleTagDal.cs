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
		public ArticleTagDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
