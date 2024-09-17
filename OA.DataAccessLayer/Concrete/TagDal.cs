using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.TagRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class TagDal : GenericRepository<Tag, InsertTagRequest, UpdateTagRequest>, ITagDal
	{
		public TagDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Tag, InsertTagRequest, UpdateTagRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
