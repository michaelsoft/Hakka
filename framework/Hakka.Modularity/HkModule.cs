using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakka.Modularity
{
    public interface IHkModule
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }

    public abstract class HkModule : IHkModule
    {
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
