using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;

namespace ClientUI.CommandHandlers;
public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{
    private readonly static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
    public Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");
        return Task.CompletedTask;
    }
}