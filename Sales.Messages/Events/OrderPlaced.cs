using NServiceBusMessaging;

namespace Sales.Messages.Events;
public class OrderPlaced : Event
{
    public string OrderId { get; set; }
}
