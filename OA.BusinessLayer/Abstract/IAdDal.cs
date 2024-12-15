using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.AdRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IAdDal : IGenericRepository<Ad, InsertAdRequest, UpdateAdRequest>
	{
	}
}
