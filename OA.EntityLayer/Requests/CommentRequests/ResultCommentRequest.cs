using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.CommentRequests
{
	public class ResultCommentRequest
	{
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public string? Username { get; set; }
        public string? Title { get; set; }
        public string? CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
