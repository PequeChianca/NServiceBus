using System.Reflection;

namespace NServiceBusMessaging;

public class AssemblyRoute
{
    public Assembly Assembly { get; set; }
    public string Route { get; set; }
}