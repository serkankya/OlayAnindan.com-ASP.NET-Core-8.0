using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.CommentRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : GenericApiController<Comment, InsertCommentRequest, UpdateCommentRequest>
	{
		public CommentController(IGenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest> repository)
			: base(repository)
		{
		}
	}
}
