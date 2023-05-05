using NServiceBusMessaging;

namespace Billing.Messages.Events;
public class OrderBilled : Event
{
    public string OrderId { get; set; }
}
