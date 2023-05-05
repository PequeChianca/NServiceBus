using NServiceBus.Logging;
using Sales.Messages.Commands;
using Sales.Messages.Events;

namespace Sales.CommandHandlers;

public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{
    private readonly static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
    public Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

        var orderPlaced = new OrderPlaced
        {
            OrderId = message.OrderId
        };

        return context.Publish(orderPlaced);
    }
}