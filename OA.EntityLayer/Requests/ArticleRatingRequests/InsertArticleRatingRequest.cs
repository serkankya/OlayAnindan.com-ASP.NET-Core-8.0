using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.ArticleRatingRequests
{
	public record InsertArticleRatingRequest(int ArticleId, int UserId, Int16 RatingValue);
}
