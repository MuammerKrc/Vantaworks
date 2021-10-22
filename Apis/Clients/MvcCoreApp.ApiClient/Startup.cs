using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MvcCoreApp.ApiClient.Configurations;
using MvcCoreApp.ApiClient.FluentValidator;
using MvcCoreApp.ApiClient.Handler;
using MvcCoreApp.ApiClient.Services;
using MvcCoreApp.ApiClient.Services.Abstracts;
using MvcCoreApp.ApiClient.Services.Abstracts.MicroservicesAbstract;
using MvcCoreApp.ApiClient.Services.Microservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient
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
           
            services.Configure<ClientSettings>(Configuration.GetSection("ClientSettings"));
            services.AddSingleton<IClientSettings>(opt =>
            {
                return opt.GetRequiredService<IOptions<ClientSettings>>().Value;
            });

            services.AddHttpContextAccessor();
            services.AddAccessTokenManagement();
            services.AddHttpClient<IPasswordCredentialsTokenService, PasswordCredentialsTokenService>();
            services.AddHttpClient<IClientCredentialsTokenService, ClientCredentialsTokenService>();
            services.AddScoped<ClientCredentialsTokenHandler>();
            services.AddScoped<PasswordCredentialsTokenHandler>();
            services.AddHttpClient<IServiceOneWithPasswordCredentialsService, ServiceOneWithPasswordCredentialsService>(opt =>
            {
                opt.BaseAddress = new Uri("https://localhost:5020/api/");
            }).AddHttpMessageHandler<PasswordCredentialsTokenHandler>();
            services.AddHttpClient<IServiceOneWithClientCredentialsService, ServiceOneWithClientCredentialsService>(opt =>
             {
                 opt.BaseAddress = new Uri("https://localhost:5020/api/");
             }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();


            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, cfg =>
            {
                cfg.LoginPath = "/Authentication/Signin";
                cfg.AccessDeniedPath = "/Authentication/AccessDenied";
                cfg.LogoutPath = "/Home/Index";
                cfg.Cookie.Name = "VantaWorks";
                cfg.ExpireTimeSpan = TimeSpan.FromDays(60);
                cfg.SlidingExpiration = true;
            });
            services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RecipeCreateValidator>());
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
