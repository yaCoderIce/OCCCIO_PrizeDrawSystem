using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model.Identity;
using PrizeDraw.Identity;

namespace PrizeDraw
{
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {            
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string connectionStringName = string.Empty;
            // Specify which connection string to use
            // @see appsettings.json
#if (DEV)
            connectionStringName = "PrizeDrawDatabaseDev";
#elif (PRD)
            connectionStringName = "PrizeDrawDatabaseProd";
#endif
            services.AddDbContext<PrizeDrawDatabaseContext>(options =>
            // Connect to database
            options.UseSqlServer(Configuration.GetConnectionString(connectionStringName)));

            services.AddIdentity<User, Role>();
            services.AddScoped<SignInManager<User>>();
            services.AddScoped<UserManager<User>, ApplicationUserManager>();  
            services.AddTransient<IUserStore<User>, LightUserStore>();
            services.AddTransient<IUserRoleStore<User>, LightUserStore>();
            services.AddTransient<IRoleStore<Role>, LightRoleStore>();

            // LoginPath,LogoutPath, AccesssDeniedPath
            // @see Areas File
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
