using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ContactInfoRequests;

namespace OA.DataAccessLayer.Concrete
{
    public class ContactInfoDal : GenericRepository<ContactInfo, InsertContactInfoRequest, UpdateContactInfoRequest>, IContactInfoDal
    {
        public ContactInfoDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<ContactInfo, InsertContactInfoRequest, UpdateContactInfoRequest>> logger)
            : base(sqlToolsProvider, dapperContext, logger)
        {

        }
    }
}
