using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.ArticleRequests
{
    public class ResultArticleRequest
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public int ViewCount { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Status { get; set; }
    }
}
