using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.MediaRequests
{
	public record UpdateMediaRequest(int MediaId, int ArticleId, string FilePath, string FileType, string AltText);
}
