namespace WebServer.Server.Handlers.Contracts
{
    using WebServer.Server.Http.Contracts;

    public interface IRequestHandler
    {
        IHttpResponse Handler(IHttpContext httpContext);
    }
}