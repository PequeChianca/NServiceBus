using NServiceBusMessaging;

namespace Billing.Messages;
public class BillingMessagesRoute
{
    public static string Route = "Billing";
    public static AssemblyRoute Create()
    {
        return new() { Assembly = typeof(BillingMessagesRoute).Assembly, Route = Route };
    }
}
