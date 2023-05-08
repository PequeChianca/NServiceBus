using Billing.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using Sales.Messages.Events;
using Shipping.Messages.Commands;
using System.Threading.Tasks;

namespace Shipping.Policies;
public class ShippingPolicy : Saga<ShippingPolicyData>, IAmStartedByMessages<OrderPlaced>, IAmStartedByMessages<OrderBilled>
{
    static ILog log = LogManager.GetLogger<ShippingPolicy>();

    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        log.Info($"Received OrderPlaced, OrderId = {message.OrderId}");
        Data.IsOrderPlaced = true;
        return ProcessOrder(context);
    }

    public Task Handle(OrderBilled message, IMessageHandlerContext context)
    {
        log.Info($"Received OrderBilled, OrderId = {message.OrderId}");
        Data.IsOrderBilled = true;
        return ProcessOrder(context);
    }

    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ShippingPolicyData> mapper)
    {
        // TODO
        mapper.MapSaga(sagadata => sagadata.OrderId)
            .ToMessage<OrderPlaced>(msg => msg.OrderId)
            .ToMessage<OrderBilled>(msg => msg.OrderId);
    }

    private async Task ProcessOrder(IMessageHandlerContext context)
    {
        if (Data.IsOrderBilled && Data.IsOrderPlaced)
        {
            await context.Send(new ShipOrder() { OrderId = Data.OrderId });
            MarkAsComplete();
        }
    }
}
