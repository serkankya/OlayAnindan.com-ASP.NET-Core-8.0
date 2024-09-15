using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.TagRequests
{
	public record UpdateTagRequest(int TagId, string TagName, bool Status);
}
