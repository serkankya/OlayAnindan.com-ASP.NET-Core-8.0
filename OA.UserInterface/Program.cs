using OA.UserInterface.Models;

namespace OA.UserInterface
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddHttpClient();

			//new Uri()
			builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettingsKey"));

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
			name: "admin",
			pattern: "Admin/{controller=Dashboard}/{action=Dashboard}/{id?}",
			defaults: new { area = "Admin" });

            app.MapControllerRoute(
            name: "user",
            pattern: "User/{controller=Home}/{action=Index}",
            defaults: new { area = "User" });

            app.Run();
		}
	}
}
