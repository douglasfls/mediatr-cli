using GenericCli;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var currentAseembly = typeof(SomeApplication).Assembly;

services.AddSingleton<SomeApplication>();
services.Scan(scan =>
    scan.FromCallingAssembly()
        .AddClasses(p =>
            p.Where(o => o.Name.EndsWith("Service") || o.Name.EndsWith("Provider")))
        .AsImplementedInterfaces()
);
services.AddMediatR(currentAseembly);

var provider = services.BuildServiceProvider();
var app = provider.GetRequiredService<SomeApplication>();

await app.Run(args);