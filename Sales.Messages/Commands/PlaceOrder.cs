using NServiceBusMessaging;

namespace Sales.Messages.Commands;
public class PlaceOrder : Command
{
    public string OrderId { get; set; }
}