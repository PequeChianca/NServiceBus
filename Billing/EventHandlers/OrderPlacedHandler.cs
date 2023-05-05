using Billing.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using Sales.Messages.Events;

namespace Billing.EventHandlers;
public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
{
    static ILog _log = LogManager.GetLogger<OrderPlacedHandler>();

    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        _log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");
        
        var orderBilled = new OrderBilled
        {
            OrderId = message.OrderId
        };

        return context.Publish(orderBilled);
    }
}
