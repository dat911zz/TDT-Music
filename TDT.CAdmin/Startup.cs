using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TDT.CAdmin.Areas.Identity.Data;
using TDT.CAdmin.Filters;
using TDT.CAdmin.Models;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils.MVCMessage;
using TDT.IdentityCore.AuthHandler;
using TDT.IdentityCore.Middlewares;
using TDT.IdentityCore.Utils;

namespace TDT.CAdmin
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
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddCors();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddTransient<IEmailSender, MailingService>();
            services.AddTransient<ISecurityHelper, SecurityHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<ErrorHandlerMiddleware>(Configuration);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                    cfg =>
                    {                      
                        cfg.LoginPath = new PathString("/Auth/Login");
                        cfg.LogoutPath = new PathString("/Auth/Logout");
                    }
                );
            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();
            services.AddMvc(cfg =>
            {
                cfg.Filters.Add<MessagesFilter>();
            }).AddControllersAsServices();
            services.AddSession();
            //services.Configure<IdentityEmailService>(Configuration);
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
            app.UseCors(policy => policy
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseSession();
            //Who are you?
            app.UseAuthentication();
            //Where you allowed?
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<RBACMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
