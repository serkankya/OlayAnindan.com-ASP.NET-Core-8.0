using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.ArticleTagRequests
{
	public class ResultArticleTagRequest
	{
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public bool Status { get; set; }
    }
}
