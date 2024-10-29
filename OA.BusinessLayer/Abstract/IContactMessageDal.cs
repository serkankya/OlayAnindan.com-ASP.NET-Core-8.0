using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ContactMessageRequests;

namespace OA.BusinessLayer.Abstract
{
    public interface IContactMessageDal : IGenericRepository<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest>
    {
    }
}
