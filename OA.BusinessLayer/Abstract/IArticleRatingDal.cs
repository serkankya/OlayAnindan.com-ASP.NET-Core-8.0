using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRatingRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IArticleRatingDal : IGenericRepository<ArticleRating, InsertArticleRatingRequest, UpdateArticleRatingRequest>
	{
	}
}
