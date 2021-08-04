using System;

namespace Hakka.Modularity
{
    public interface IDependedModulesProvider
    {
        Type[] GetDependedModules();
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false)]
    public class DependsOnAttribute : Attribute, IDependedModulesProvider
    {
        public Type[] DependedModules { get; }

        public DependsOnAttribute(params Type[] dependedModules)
        {
            DependedModules = dependedModules ?? new Type[0];
        }

        public Type[] GetDependedModules()
        {
            return this.DependedModules;
        }
    }
}
