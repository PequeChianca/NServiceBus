using NServiceBusMessaging;
using Shipping.Messages;
using System;

var serviceName = ShippingMessageRoute.Route;
Console.Title = serviceName;

var endpointInstance = await NServiceBusExtensions.AddNServiceBusMessaging(serviceName, ShippingMessageRoute.Create());

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();
await endpointInstance.Stop().ConfigureAwait(false);
