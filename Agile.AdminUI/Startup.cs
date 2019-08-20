using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.BaseLib.Extensions;
using Agile.BaseLib.Filters;
using Agile.BaseLib.IoC;
using Agile.BaseLib.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agile.AdminUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
            {
                option.LoginPath = "/SignIn";
                option.AccessDeniedPath = "/Home/Error";
                option.Cookie.HttpOnly = true;
            });

            services.Configure<DbContextOption>(Configuration.GetSection("ConnectionStrings"));

            //services.AddSingleton(Configuration);
            services.AddScopedAssembly("Agile.Repository");
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//用于获取请求上下文
            services.AddMvc(option =>
            {
                option.Filters.Add(new GlobalExceptionFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return AspectCoreContainer.BuildServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMiddleware<ResponseTimeMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
