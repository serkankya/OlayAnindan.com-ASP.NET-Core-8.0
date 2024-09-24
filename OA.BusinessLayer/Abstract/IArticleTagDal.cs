using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleTagRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IArticleTagDal : IGenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>
	{
		Task<List<ResultArticleTagRequest>> GetResultArticleTags();
		Task<List<ResultArticleTagRequest>> GetResultArticleTagsById(int articleId);
	}
}
