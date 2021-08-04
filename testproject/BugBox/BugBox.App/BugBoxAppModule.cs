using Hakka.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugBox.App
{
    public class BugBoxAppModule : HkModule
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
