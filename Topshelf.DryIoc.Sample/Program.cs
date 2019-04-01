using System;
using DryIoc;

namespace Topshelf.DryIoc.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Create DryIoc container
            var container = new Container();
            container.Register<ISampleService, SampleService>();
            container.Register<ISampleLogger, SampleLogger>();

            var rc = HostFactory.Run(x =>
            {
                // 2. Use DryIoc container
                x.UseDryIocContainer(container);

                x.Service<ISampleService>(s =>
                {
                    // 3. Resolve dependencies using DryIoc
                    s.ConstructUsingDryIocContainer();

                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf integration with DryIoc");
                x.SetDisplayName("Topshelf.DryIoc");
                x.SetServiceName("Topshelf.DryIoc");
            });

            var exitCode = (int) Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
