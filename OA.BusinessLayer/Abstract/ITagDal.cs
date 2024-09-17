using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.TagRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface ITagDal : IGenericRepository<Tag, InsertTagRequest, UpdateTagRequest>
	{
	}
}
