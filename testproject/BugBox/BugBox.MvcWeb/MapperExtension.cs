using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugBox.MvcWeb
{
    public static class MapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Add profiles of current assembly
                cfg.AddMaps(System.AppDomain.CurrentDomain.GetAssemblies());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }
    }
}
