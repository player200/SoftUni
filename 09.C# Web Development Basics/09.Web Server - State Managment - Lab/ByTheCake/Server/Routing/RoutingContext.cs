namespace ByTheCake.Server.Routing
{
    using ByTheCake.Server.Handlers;
    using ByTheCake.Server.Routing.Contracts;
    using System.Collections.Generic;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler handler, IEnumerable<string> parameters)
        {
            this.Handler = handler;
            this.Parameters = parameters;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler Handler { get; private set; }
    }
}