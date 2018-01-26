namespace WebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using WebServer.Server.Handlers;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}