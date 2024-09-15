using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.CategoryRequests
{
	public record InsertCategoryRequest(string CategoryName, string Description);
}
