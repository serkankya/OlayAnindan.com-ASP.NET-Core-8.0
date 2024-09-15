using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.CommentRequests
{
	public record InsertCommentRequest(int ArticleId, int UserId, string CommentText);
}
