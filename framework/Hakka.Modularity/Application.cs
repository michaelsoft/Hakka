using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakka.Modularity
{
    public class Application : ApplicationBase
    {
        private IServiceCollection Services { get; }

        private IConfiguration Configuration { get; }

        private List<HkModule> Modules { get; set; } = new List<HkModule>();

        public Application(IServiceCollection services, IConfiguration configuration, Type startUpModuleType)
        {
            this.Services = services;
            this.Configuration = configuration;
            this.LoadModules(startUpModuleType);
            this.ConfigureModules();
        }

        private void LoadModules(Type startUpModuleType)
        {
            var dependedModulesProviders = startUpModuleType.GetCustomAttributes(false).OfType<IDependedModulesProvider>();

            List<Type> moduleTypes = new List<Type>();
            foreach (var dependedModulesProvider in dependedModulesProviders)
            {
                foreach (var moduleType in dependedModulesProvider.GetDependedModules())
                {
                    moduleTypes.Add(moduleType);
                }
            }

            moduleTypes.Add(startUpModuleType);

            foreach (var moduleType in moduleTypes)
            {
                var module = this.CreateModuleInstance(moduleType);
                this.Services.Add(new ServiceDescriptor(moduleType, module));
            }

        }

        private HkModule CreateModuleInstance(Type moduleType)
        {
            return (HkModule)Activator.CreateInstance(moduleType);
        }

        private void ConfigureModules()
        {
            foreach(var module in this.Modules)
            {
                module.ConfigureServices(this.Services, this.Configuration);
            }
        }


    }
}
