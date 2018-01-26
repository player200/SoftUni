namespace WebServer.Server.Contracts
{
    using WebServer.Server.Routing.Contracts;

    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}