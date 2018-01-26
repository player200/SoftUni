namespace WebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using WebServer.Server.Enums;

    public interface IServerRouteConfig
    {
        Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}