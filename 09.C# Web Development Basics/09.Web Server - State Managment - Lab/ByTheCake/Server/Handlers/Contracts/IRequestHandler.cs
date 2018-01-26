namespace ByTheCake.Server.Handlers.Contracts
{
    using ByTheCake.Server.Http.Contracts;

    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext context);
    }
}