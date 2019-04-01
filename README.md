# Topshelf.DryIoc
Topshelf integration with DryIoc

[![NuGet Badge](https://buildstats.info/nuget/Topshelf.DryIoc)](https://www.nuget.org/packages/Topshelf.DryIoc)
[![Build Status](https://dev.azure.com/matkul3/Topshelf.DryIoc/_apis/build/status/mat-kul.Topshelf.DryIoc?branchName=master)](https://dev.azure.com/matkul3/Topshelf.DryIoc/_build/latest?definitionId=1&branchName=master)

Supports .Net Framework 4.5.2, .Net Standard 2.0

## Sample

``` csharp
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
```

For full example code go to [Topshelf.DryIoc.Sample](https://github.com/mat-kul/Topshelf.DryIoc/tree/master/Topshelf.DryIoc.Sample). 
