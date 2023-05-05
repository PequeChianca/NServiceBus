using NServiceBus.Transport;
using System.Reflection;

namespace NServiceBusMessaging;

public static class NServiceBusExtensions
{
    public static async Task<IEndpointInstance> AddNServiceBusMessaging(string endpointName, params AssemblyRoute[] assemblies)
    {
        Console.WriteLine($"Starting endpoint {endpointName}");
        var endpointConfig = new EndpointConfiguration(endpointName);
        var transport = endpointConfig.UseTransport<LearningTransport>();

        foreach (var assemblyRoute in assemblies)
        {
            transport.Routing().RouteEndpoints(assemblyRoute.Route, assemblyRoute.Assembly);
        }

        return await Endpoint.Start(endpointConfig).ConfigureAwait(false);
    }

    public static async Task RunJob(this IEndpointInstance endpointInstance, Func<IEndpointInstance, Task> job = null)
    {
        if (job != null)
            await job(endpointInstance).ConfigureAwait(false);

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
        await endpointInstance.Stop().ConfigureAwait(false);
    }

    private static void RouteEndpoints<TTransport>(this RoutingSettings<TTransport> routing, string route, Assembly assembly) where TTransport : TransportDefinition
    {
        var commands = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Command)) && !t.IsAbstract).ToList();

        foreach (var command in commands)
        {
            routing.RouteToEndpoint(command, route);
        }
    }
}
