using NServiceBus.Logging;
using Sales.Messages.Commands;
using Sales.Messages.Events;

namespace Sales.Policies;
public class BuyersRemorsePolicy : Saga<BuyersRemorseState>, IAmStartedByMessages<PlaceOrder>, IHandleTimeouts<BuyersRemorseIsOver>, IHandleMessages<CancelOrder>
{
    static ILog _log = LogManager.GetLogger<BuyersRemorsePolicy>();
    public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        _log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

        _log.Info($"Starting cool down period for order #{Data.OrderId}.");
        await RequestTimeout(context, TimeSpan.FromSeconds(20), new BuyersRemorseIsOver());
    }

    public Task Handle(CancelOrder message, IMessageHandlerContext context)
    {
        _log.Info($"Order #{message.OrderId} was cancelled.");

        //TODO: Possibly publish an OrderCancelled event?

        MarkAsComplete();
        
        return Task.CompletedTask;
    }

    public async Task Timeout(BuyersRemorseIsOver state, IMessageHandlerContext context)
    {
        _log.Info($"Cooling down period for order #{Data.OrderId} has elapsed.");

        var orderPlaced = new OrderPlaced
        {
            OrderId = Data.OrderId
        };

        await context.Publish(orderPlaced);

        MarkAsComplete();
    }

    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<BuyersRemorseState> mapper)
    {
        //TODO 
        mapper.MapSaga(sagaData => sagaData.OrderId)
            .ToMessage<PlaceOrder>(order => order.OrderId)
            .ToMessage<CancelOrder>(order => order.OrderId);
    }
}

