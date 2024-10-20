using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CommentRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : GenericApiController<Comment, InsertCommentRequest, UpdateCommentRequest>
	{
		readonly ICommentDal _commentDal;

		public CommentController(IGenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest> repository, ICommentDal commentDal)
			: base(repository)
		{
			_commentDal = commentDal;
		}

		[HttpGet("GetResultComments")]
		public async Task<IActionResult> GetResultComments()
		{
			var values = await _commentDal.GetResultComments();
			return Ok(values);
		}

		[HttpGet("GetResultCommentsById/{articleId}")]
		public async Task<IActionResult> GetResultComments(int articleId)
		{
			var values = await _commentDal.GetResultCommentsById(articleId);
			return Ok(values);
		}

		[HttpPut("ActivateComment/{id}")]
		public async Task<IActionResult> ActivateComment(int id)
		{
			bool isActivated = await _commentDal.ActivateComment(id);

			if (isActivated == false)
			{
				return BadRequest("Activation failed.");
			}

			return Ok("Comment activated successfully.");
		}
	}
}
