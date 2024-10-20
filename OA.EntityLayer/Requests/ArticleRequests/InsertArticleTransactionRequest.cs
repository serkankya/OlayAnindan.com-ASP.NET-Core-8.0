using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.ArticleRequests
{
	public record InsertArticleTransactionRequest(int UserId, int CategoryId, string MainTitle, string MainText, string FirstTitle, string FirstText, string SecondTitle, string SecondText, string Summary, bool IsFeatured, string MainMediaPath, string MainMediaType, string FirstMediaPath, string FirstMediaType, string SecondMediaPath, string SecondMediaType, List<string> TagName);
}

