using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.MediaRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IMediaDal : IGenericRepository<Media, InsertMediaRequest, UpdateMediaRequest>
	{
	}
}
