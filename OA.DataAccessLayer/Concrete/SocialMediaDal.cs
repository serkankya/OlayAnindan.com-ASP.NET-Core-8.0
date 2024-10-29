using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.SocialMediaRequests;

namespace OA.DataAccessLayer.Concrete
{
	internal class SocialMediaDal : GenericRepository<SocialMedia, InsertSocialMediaRequest, UpdateSocialMediaRequest>, ISocialMediaDal
	{
		public SocialMediaDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<SocialMedia, InsertSocialMediaRequest, UpdateSocialMediaRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
