using NServiceBus;
using NServiceBus.Logging;
using Shipping.Messages.Commands;
using System.Threading.Tasks;

namespace Shipping.CommandHandlers;
public class ShipOrderHandler : IHandleMessages<ShipOrder>
{
    static ILog log = LogManager.GetLogger<ShipOrderHandler>();

    public Task Handle(ShipOrder message, IMessageHandlerContext context)
    {
        log.Info($"Order [{message.OrderId}] - Successfully shipped.");
        return Task.CompletedTask;
    }
}
