using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.MediaRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class MediaDal : GenericRepository<Media, InsertMediaRequest, UpdateMediaRequest>, IMediaDal
	{
		public MediaDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Media, InsertMediaRequest, UpdateMediaRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
