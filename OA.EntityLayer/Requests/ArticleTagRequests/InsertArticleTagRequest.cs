using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.ArticleTagRequests
{
	public record InsertArticleTagRequest(int ArticleId, int TagId);
}
