namespace ByTheCake.Server.Routing.Contracts
{
    using ByTheCake.Server.Handlers;
    using System.Collections.Generic;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler Handler { get; }
    }
}