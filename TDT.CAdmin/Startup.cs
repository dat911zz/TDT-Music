using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Security.Claims;
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
            services.AddControllersWithViews(cfg =>
                    cfg.Filters.Add<DVNAuthorizationFilter>())
                .AddRazorRuntimeCompilation();
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
                        cfg.AccessDeniedPath = new PathString("/Home/Error?errorCode=401");
                        //cfg.SlidingExpiration = true;
                        cfg.ExpireTimeSpan = TimeSpan.FromMinutes(Configuration.GetValue<double>("IdleTimeoutMinutes"));
                    }
                );
            services.AddAuthorization();
            services.AddScoped<IActionFilter, DVNAuthorizationFilter>();
            services.AddMvc(cfg =>
            {
                cfg.Filters.Add<MessagesFilter>();
                cfg.Filters.Add<DVNAuthorizationFilter>();
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
