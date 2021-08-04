using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BugBox.App;
using System;
using System.Collections.Generic;

namespace BugBox.MvcWeb
{
    public static class AutoMapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            Type[] modules = new Type[] { typeof(BugBoxAppModule), typeof(BugBoxMvcWebModule) };
            List<Action<IMapperConfigurationExpression>> actions = new List<Action<IMapperConfigurationExpression>>();
            foreach (var module in modules)
            {
                actions.Add(cfg => cfg.AddMaps(module.Assembly));
            }

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var action in actions)
                {
                    action(cfg);
                }
            });

            //var config = new MapperConfiguration(cfg =>
            //{
            //    //Add profiles of current assembly
            //    cfg.AddMaps(System.AppDomain.CurrentDomain.GetAssemblies());
            //    cfg.AddMaps(typeof(AppMapperProfile).Assembly); //ToDo: Use module name to load
            //});

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }
    }
}
