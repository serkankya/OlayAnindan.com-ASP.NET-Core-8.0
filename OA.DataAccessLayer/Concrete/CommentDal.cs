using Dapper;
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
		readonly IDapperContext _dapperContext;
		public CommentDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{
			_dapperContext = dapperContext;
		}

		public async Task<List<ResultCommentRequest>> GetResultComments()
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForComments = "SELECT c.CommentId, a.ArticleId, u.UserId, u.Username, a.Title, c.CommentText, c.CreatedDate, c.Status FROM Comments c INNER JOIN Users u ON c.UserId = u.UserId INNER JOIN Articles a ON a.ArticleId = c.ArticleId";

				var values = await connection.QueryAsync<ResultCommentRequest>(queryForComments);
				return values.ToList();
			}
		}
	}
}
