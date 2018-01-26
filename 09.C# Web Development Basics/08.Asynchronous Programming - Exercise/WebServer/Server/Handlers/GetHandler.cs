namespace WebServer.Server.Handlers
{
    using System;
    using WebServer.Server.Http.Contracts;

    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpContext, IHttpResponse> func) : base(func)
        {
        }
    }
}