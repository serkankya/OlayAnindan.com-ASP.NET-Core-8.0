using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.SocialMediaRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface ISocialMediaDal : IGenericRepository<SocialMedia,InsertSocialMediaRequest, UpdateSocialMediaRequest>
	{
	}
}
