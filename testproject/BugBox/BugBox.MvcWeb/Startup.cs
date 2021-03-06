using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using BugBox.App.Contracts.Bugs;
using BugBox.App.Bugs;
using BugBox.Repository.EF;
using Microsoft.EntityFrameworkCore;
using BugBox.Domain.Bugs;
using BugBox.Repository.EF.Bugs;
using Hakka.Modularity;


namespace BugBox.MvcWeb
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
            services.AddApplication<BugBoxMvcWebModule>(this.Configuration);
            //services.AddControllersWithViews();

            //services.AddDbContext<BugBoxDbContext>(options => 
            //  options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //services.AddScoped<IBugRepository, BugRepository>();
            //services.AddScoped<IBugAppService, BugAppService>();
            //services.AddMapper();


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
            }
            app.UseStaticFiles();

            app.UseRouting();

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
