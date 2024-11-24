using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.SubscriberRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface ISubscriberDal : IGenericRepository<Subscriber, InsertSubscriberRequest, UpdateSubscriberRequest>
	{
	}
}
