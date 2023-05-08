using NServiceBusMessaging;

namespace Shipping.Messages;
public static class ShippingMessageRoute
{
    public static string Route = "Shipping";
    public static AssemblyRoute Create()
    {
        return new() { Assembly = typeof(ShippingMessageRoute).Assembly, Route = Route };
    }
}
