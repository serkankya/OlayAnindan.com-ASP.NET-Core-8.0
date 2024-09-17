using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.RoleRequests;

namespace OA.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : GenericApiController<Role, InsertRoleRequest, UpdateRoleRequest>
	{
        public RoleController(IGenericRepository<Role, InsertRoleRequest, UpdateRoleRequest> repository) : base(repository) 
        {
        }
    }
}
