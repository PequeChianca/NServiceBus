using NServiceBus;
using NServiceBus.Logging;
using Sales.Messages.Events;

namespace Shipping.EventHandlers;
public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
{
    static ILog _log = LogManager.GetLogger<OrderPlacedHandler>();
    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        _log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Should we ship now?");
        return Task.CompletedTask;
    }
}
