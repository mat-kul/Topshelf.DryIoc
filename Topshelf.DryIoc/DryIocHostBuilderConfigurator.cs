using System.Collections.Generic;
using DryIoc;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.DryIoc
{
    public class DryIocHostBuilderConfigurator : HostBuilderConfigurator
    {
        public DryIocHostBuilderConfigurator(IContainer container)
        {
            Container = container;
        }

        public static IContainer Container { get; set; }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }

        public HostBuilder Configure(HostBuilder builder) => builder;
    }
}
