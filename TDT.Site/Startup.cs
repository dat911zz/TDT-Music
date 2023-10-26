using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils.MVCMessage;
using TDT.IdentityCore.Middlewares;
using TDT.IdentityCore.Utils;

namespace TDT.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.Configure<ErrorHandlerMiddleware>(Configuration);
			services.AddTransient<IEmailSender, MailingService>();
			services.AddTransient<ISecurityHelper, SecurityHelper>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
					cfg =>
					{
						cfg.LoginPath = new PathString("/Auth");
						cfg.LogoutPath = new PathString("/Auth/Logout");
					}
				);
			services.AddMvc(cfg =>
            {
                cfg.Filters.Add<MessagesFilter>();
            }).AddControllersAsServices();
			services.AddSession();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
			app.UseSession();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
