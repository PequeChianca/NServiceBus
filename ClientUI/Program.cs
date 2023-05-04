
var serviceName = "ClientUI";
Console.Title = serviceName;
Console.WriteLine($"Start {serviceName}");
var endpointConfig = new EndpointConfiguration(serviceName);
var transport = endpointConfig.UseTransport<LearningTransport>();
var endpointInstance = await Endpoint.Start(endpointConfig).ConfigureAwait(false);

await ClientUI.HumanInteraction.StartConsole(endpointInstance).ConfigureAwait(false);

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();

await endpointInstance.Stop().ConfigureAwait(false);