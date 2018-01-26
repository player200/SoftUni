namespace WebServer.Server.Handlers
{
    using System;
    using WebServer.Server.Handlers.Contracts;
    using WebServer.Server.Http.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpContext, IHttpResponse> func;

        protected RequestHandler(Func<IHttpContext, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handler(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.func.Invoke(httpContext);

            httpResponse.AddHeader("Content-Type", "text/html");

            return httpResponse;
        }
    }
}