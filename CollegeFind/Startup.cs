using CollegeFind.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CollegeFind
{
    public class Startup
    {
        private IHostingEnvironment a { get; set; }
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            a = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //if (a.IsDevelopment())
            //{
            //    services.AddScoped<ICollegeData, InMemoryCollegeData>();
            //}
            //else if (a.IsProduction())
            //{
            //    services.AddScoped<ICollegeData, SqlCollegeData>();
            //}
            //    services
            ////.AddEntityFramework()
            //.AddSqlServer()
            //.AddDbContext<CollegeFindDBContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnextionString("CollegeFindDB"))
            //.AddDbContext<CollegeFindContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnextionString("CollegeFindContextConnection"));

            services.AddDbContext<CollegeFindDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CollegeFindDB"));
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CollegeFindDB"));
            });
            // hve migrtion kari nakh


            //services.AddDbContextPool<CollegeFindContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("CollegeFindContextConnection"));
            //});
            //services.AddScoped<ICollegeData,InMemoryCollegeData>();
            services.AddScoped<ICollegeData, SqlCollegeData>();

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
