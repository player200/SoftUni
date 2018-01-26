namespace ByTheCake.Server.Contracts
{
    using ByTheCake.Server.Routing.Contracts;

    public interface IApplication
    {
        void Configure(IAppRouteConfig appRouteConfig);
    }
}