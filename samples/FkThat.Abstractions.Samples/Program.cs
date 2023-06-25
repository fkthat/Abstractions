using System.Reflection;

using FkThat.Abstractions;
using FkThat.Abstractions.Samples;

using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();

services.AddTransient<IClock, SystemClock>();

foreach (var t in Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract &&
            t.IsAssignableTo(typeof(ISample))))
{
    services.AddTransient(typeof(ISample), t);
}

using var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

foreach (var sample in scope.ServiceProvider.GetRequiredService<IEnumerable<ISample>>())
{
    await sample.RunAsync();
}
