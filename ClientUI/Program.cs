using ClientUI;
using NServiceBusMessaging;
using Sales.Messages;

var serviceName = "ClientUI";
Console.Title = serviceName;

var endpointInstance = await NServiceBusExtensions.AddNServiceBusMessaging(serviceName, SalesMessageRoute.Create());

await endpointInstance.RunJob(HumanInteraction.StartConsole);


