﻿using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.RoleRequests;

namespace OA.DataAccessLayer.Concrete
{
	public class RoleDal : GenericRepository<Role, InsertRoleRequest, UpdateRoleRequest>, IRoleDal
	{
		public RoleDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Role, InsertRoleRequest, UpdateRoleRequest>> logger)
			: base(sqlToolsProvider, dapperContext, logger)
		{

		}
	}
}
