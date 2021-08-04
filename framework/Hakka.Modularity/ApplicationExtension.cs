using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hakka.Modularity
{
    public static class ApplicationExtension
    {
        public static void AddApplication<TStartUpModule>(this IServiceCollection services, IConfiguration configuration)
        {
            var application = new Application(services, configuration, typeof(TStartUpModule));
        }
    }
}
