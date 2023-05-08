using NServiceBusMessaging;

namespace Sales.Messages.Commands;
public class CancelOrder : Command
{
    public string OrderId { get; set; }
}
