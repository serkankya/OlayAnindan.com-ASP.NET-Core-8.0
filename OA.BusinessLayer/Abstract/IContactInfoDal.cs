using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ContactInfoRequests;

namespace OA.BusinessLayer.Abstract
{
    public interface IContactInfoDal : IGenericRepository<ContactInfo, InsertContactInfoRequest, UpdateContactInfoRequest> 
    {
    }
}
