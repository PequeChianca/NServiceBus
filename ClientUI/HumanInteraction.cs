using Messages.Commands;
using NServiceBus.Logging;

namespace ClientUI;
public static class HumanInteraction
{
    static ILog log = LogManager.GetLogger<Program>();

    public static async Task StartConsole(IEndpointInstance endpointInstance)
    {
        while (true)
        {
            log.Info("Press 'P' to place an order, or 'Q' to quit.");
            var key = Console.ReadKey();
            Console.WriteLine();

            switch (key.Key)
            {
                case ConsoleKey.P:
                    // Instantiate the command
                    var command = new PlaceOrder
                    {
                        OrderId = Guid.NewGuid().ToString()
                    };

                    // Send the command to the local endpoint
                    log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}");
                    await endpointInstance.SendLocal(command)
                        .ConfigureAwait(false);

                    break;

                case ConsoleKey.Q:
                    return;

                default:
                    log.Info("Unknown input. Please try again.");
                    break;
            }
        }
    }
}