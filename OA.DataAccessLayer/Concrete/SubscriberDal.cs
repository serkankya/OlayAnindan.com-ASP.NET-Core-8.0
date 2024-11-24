using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.SubscriberRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class SubscriberDal : GenericRepository<Subscriber, InsertSubscriberRequest, UpdateSubscriberRequest>, ISubscriberDal
	{
		public SubscriberDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Subscriber, InsertSubscriberRequest, UpdateSubscriberRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
