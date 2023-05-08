using NServiceBusMessaging;

namespace Shipping.Messages.Commands;
public class ShipOrder : Command
{
    public string OrderId { get; set; }
}
