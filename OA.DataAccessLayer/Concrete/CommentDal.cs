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

		public async Task<bool> ActivateComment(int id)
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForActivate = "UPDATE Comments SET Status = 1 WHERE CommentId = @commentId";

				var parameters = new DynamicParameters();
				parameters.Add("@commentId", id);

				int affectedRows = await connection.ExecuteAsync(queryForActivate, parameters);

				if (affectedRows > 0)
				{
					return true;
				}

				return false;
			}
		}

		public async Task<List<ResultCommentRequest>> GetResultComments()
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForComments = "SELECT c.CommentId, a.ArticleId, u.UserId, u.Username, u.Email, u.FullName, a.MainTitle, c.CommentText, c.CreatedDate, c.Status FROM Comments c INNER JOIN Users u ON c.UserId = u.UserId INNER JOIN Articles a ON a.ArticleId = c.ArticleId";

				var values = await connection.QueryAsync<ResultCommentRequest>(queryForComments);
				return values.ToList();
			}
		}

		public async Task<List<ResultCommentRequest>> GetResultCommentsById(int articleId)
		{
			using (var connection = _dapperContext.GetConnection())
			{
				string queryForComments = "SELECT c.CommentId, a.ArticleId, u.UserId, u.Username, u.Email, u.FullName, u.ImageUrl, a.MainTitle, c.CommentText, c.CreatedDate, c.Status FROM Comments c INNER JOIN Users u ON c.UserId = u.UserId INNER JOIN Articles a ON a.ArticleId = c.ArticleId WHERE c.ArticleId = @articleId";

				var parameters = new DynamicParameters();
				parameters.Add("@articleId", articleId);

				var values = await connection.QueryAsync<ResultCommentRequest>(queryForComments, parameters);
				return values.ToList();
			}
		}
	}
}
