using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.CategoryRequests
{
	public record UpdateCategoryRequest(int CategoryId, string CategoryName, string Description, DateTime UpdatedDate, bool Status);
}
