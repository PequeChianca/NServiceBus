using NServiceBusMessaging;

namespace Sales.Messages;
public static class SalesMessageRoute
{
    public static string Route = "Sales";
    public static AssemblyRoute Create()
    {
        return new() { Assembly = typeof(SalesMessageRoute).Assembly, Route = Route };
    }
}
