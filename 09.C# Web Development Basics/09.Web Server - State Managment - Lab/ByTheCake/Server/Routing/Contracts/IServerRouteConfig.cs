namespace ByTheCake.Server.Routing.Contracts
{
    using ByTheCake.Server.Enums;
    using System.Collections.Generic;

    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }
    }
}