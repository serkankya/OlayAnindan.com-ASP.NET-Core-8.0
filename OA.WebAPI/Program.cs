
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete;
using OA.DataAccessLayer.Concrete.Dapper;
using OA.DataAccessLayer.Concrete.GenericRepository;

namespace OA.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.Configure<ContextOption>(builder.Configuration.GetSection(ContextOption.ConnectionString));


			builder.Services.AddTransient<IDapperContext, DapperContext>();
			builder.Services.AddTransient<ISqlToolsProvider, SqlToolsProvider>();

			builder.Services.AddTransient<IRoleDal, RoleDal>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
