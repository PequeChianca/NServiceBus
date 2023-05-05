using Billing.Messages;
using NServiceBusMessaging;

var serviceName = BillingMessagesRoute.Route;
Console.Title = serviceName;

var endpointInstance = await NServiceBusExtensions.AddNServiceBusMessaging(serviceName);

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();
await endpointInstance.Stop().ConfigureAwait(false);
