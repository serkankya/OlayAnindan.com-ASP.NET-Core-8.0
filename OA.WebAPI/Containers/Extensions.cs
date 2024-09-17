using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete;
using OA.DataAccessLayer.Concrete.Dapper;
using OA.DataAccessLayer.Concrete.GenericRepository;

namespace OA.WebAPI.Containers
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddTransient<IDapperContext, DapperContext>();
			services.AddTransient<ISqlToolsProvider, SqlToolsProvider>();

			
			services.AddTransient<IRoleDal, RoleDal>();
		}
	}
}
