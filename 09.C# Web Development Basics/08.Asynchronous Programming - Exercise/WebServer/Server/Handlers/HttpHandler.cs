namespace WebServer.Server.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using WebServer.Application.Views;
    using WebServer.Server.Handlers.Contracts;
    using WebServer.Server.Http.Contracts;
    using WebServer.Server.Http.Response;
    using WebServer.Server.Routing.Contracts;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handler(IHttpContext httpContext)
        {
            foreach (KeyValuePair<string, IRoutingContext> kvp in this.serverRouteConfig.Routes[httpContext.Request.RequestMethod])
            {
                string pattern = kvp.Key;
                Regex regex = new Regex(pattern);
                Match match = regex.Match(httpContext.Request.Path);

                if (!match.Success)
                {
                    continue;
                }

                foreach (string parameter in kvp.Value.Parameters)
                {
                    httpContext.Request.AddUrlParameter(parameter, match.Groups[parameter].Value);
                }

                return kvp.Value.RequestHandler.Handler(httpContext);
            }

            return new ViewResponse(Enums.HttpStatusCode.NotFound, new NotFoundView());
        }
    }
}