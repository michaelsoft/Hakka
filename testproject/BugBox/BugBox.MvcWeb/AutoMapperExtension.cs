using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BugBox.App;

namespace BugBox.MvcWeb
{
    public static class AutoMapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Add profiles of current assembly
                cfg.AddMaps(System.AppDomain.CurrentDomain.GetAssemblies());
                cfg.AddMaps(typeof(AppMapperProfile).Assembly); //ToDo: Use module name to load
            });
           

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }
    }
}
