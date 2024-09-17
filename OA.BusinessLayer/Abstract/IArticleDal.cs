using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IArticleDal : IGenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>
	{
	}
}
