using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CommentRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface ICommentDal: IGenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest>
	{
		Task<List<ResultCommentRequest>> GetResultComments();
		Task<bool> ActivateComment(int id);
	}
}
