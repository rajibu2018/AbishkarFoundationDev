using AbishkarFoundation.CoreService.Impl;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Repository;
using AbishkarFoundation.Repository.Impl;
using AbishkarFoundation.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace AbishKarFoundation
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
            //services.AddTransient<ISessionFactory,AbishkarFoundation.S>
            //services.AddScoped(UserRepository);
            //#region Repository

            //services.AddScoped<ISession>((provider) =>
            //{
            //    var factory = provider.GetService<ISessionFactory>();
            //    return factory.OpenSession();
            //});
            //services.AddScoped<IUserRepository, UserRepository>();
            //#endregion
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Login/";

                    });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            #region Service
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserAccountService, UserAccountService>();
            #endregion
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
  
}
