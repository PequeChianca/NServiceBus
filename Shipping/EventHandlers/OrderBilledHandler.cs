using Billing.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping.EventHandlers;
public class OrderBilledHandler : IHandleMessages<OrderBilled>
{
    static ILog _log = LogManager.GetLogger<OrderBilledHandler>();

    public Task Handle(OrderBilled message, IMessageHandlerContext context)
    {
        _log.Info($"Received OrderBilled, OrderId = {message.OrderId} - Should we ship now?");
        return Task.CompletedTask;
    }
}
