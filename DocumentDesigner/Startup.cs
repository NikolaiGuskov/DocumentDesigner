using DocumentDesigner.WebApi.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocumentDesigner.Application.Extensions;
using DocumentDesigner.Persistence.Extensions;

namespace DocumentDesigner
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Authentication/Login");
				});
			services.AddControllersWithViews();
			services.AddRazorPages();
			services.AddHttpContextAccessor();

			services.AddTransient<IAuthenticationService, AuthenticationService>();
			services.AddTransient<ICustomViewRendererService, CustomViewRendererService>();

			services.AddApplication();
			services.AddPersistense();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			env.EnvironmentName = "Production";
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Document/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Document}/{action=Index}/{id?}");
			});
		}
	}
}
