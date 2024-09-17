using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CommentRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class CommentDal : GenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest>, ICommentDal
	{
		public CommentDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
