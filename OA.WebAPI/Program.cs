using FluentValidation;
using FluentValidation.AspNetCore;
using OA.DataAccessLayer.Concrete.Dapper;
using OA.WebAPI.Containers;
using OA.WebAPI.FluentValidation;
using OA.WebAPI.JwtTools;

namespace OA.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddJwtAuthentication(builder.Configuration);

			builder.Services.AddControllers();

			//Fluent validation
			builder.Services.AddFluentValidationAutoValidation()
				.AddFluentValidationClientsideAdapters();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//Database connection string
			builder.Services.Configure<ContextOption>(builder.Configuration.GetSection(ContextOption.ConnectionString));

			//Containers --> Extensions
			builder.Services.ContainerDependencies();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			//For JWT(Before authorization)
			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
