using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ContactMessageRequests;

namespace OA.DataAccessLayer.Concrete
{
    public class ContactMessageDal : GenericRepository<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest>, IContactMessageDal
    {
        public ContactMessageDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest>> logger)
            : base(sqlToolsProvider, dapperContext, logger)
        {

        }
    }
}
