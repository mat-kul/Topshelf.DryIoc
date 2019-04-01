using DryIoc;
using Topshelf.ServiceConfigurators;

namespace Topshelf.DryIoc
{
    public static class ServiceConfiguratorExtensions
    {
        public static ServiceConfigurator<T> ConstructUsingDryIocContainer<T>(this ServiceConfigurator<T> configurator) where T : class
        {
            configurator.ConstructUsing(serviceFactory => DryIocHostBuilderConfigurator.Container.Resolve<T>());
            return configurator;
        }
    }
}
