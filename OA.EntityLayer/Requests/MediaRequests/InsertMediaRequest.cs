using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.MediaRequests
{
	public record InsertMediaRequest(int ArticleId, string FilePath, string FileType, string AltText);
}
