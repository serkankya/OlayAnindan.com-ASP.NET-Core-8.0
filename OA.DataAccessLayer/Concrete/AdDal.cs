using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.AdRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class AdDal : GenericRepository<Ad, InsertAdRequest, UpdateAdRequest>, IAdDal
	{
		public AdDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Ad, InsertAdRequest, UpdateAdRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
