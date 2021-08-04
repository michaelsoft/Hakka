using AutoMapper;
using BugBox.App;
using BugBox.App.Bugs;
using BugBox.App.Contracts.Bugs;
using BugBox.Domain.Bugs;
using BugBox.Repository.EF;
using BugBox.Repository.EF.Bugs;
using Hakka.Modularity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugBox.MvcWeb
{
    [DependsOn(typeof(BugBoxAppModule))]
    public class BugBoxMvcWebModule : HkModule
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BugBoxDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped<IBugRepository, BugRepository>();
            services.AddScoped<IBugAppService, BugAppService>();
            AddMapper(services);
        }

        private void AddMapper(IServiceCollection services)
        {
            var dependedModulesProviders = this.GetType().GetCustomAttributes(false).OfType<IDependedModulesProvider>();
            //Type[] modules = new Type[] { typeof(BugBoxAppModule), typeof(BugBoxMvcWebModule) };
            List<Action<IMapperConfigurationExpression>> actions = new List<Action<IMapperConfigurationExpression>>();

            foreach(var dependedModulesProvider in dependedModulesProviders)
            {
                foreach (var module in dependedModulesProvider.GetDependedModules())
                {
                    actions.Add(cfg => cfg.AddMaps(module.Assembly));
                }
            }

            actions.Add(cfg => cfg.AddMaps(this.GetType().Assembly));

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var action in actions)
                {
                    action(cfg);
                }
            });

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }
    }
}
