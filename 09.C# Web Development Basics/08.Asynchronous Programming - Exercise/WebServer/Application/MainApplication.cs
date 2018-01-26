namespace WebServer.Application
{
    using WebServer.Application.Controllers;
    using WebServer.Server.Contracts;
    using WebServer.Server.Handlers;
    using WebServer.Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute(
                "/register",
                new PostHandler(
                    httpContext => new UserController()
                    .RegisterPost(httpContext.Request.FormData["name"])));

            appRouteConfig.AddRoute(
                "/register",
                new GetHandler(httpContext => new UserController().RegisterGet()));

            appRouteConfig.AddRoute(
                "/user/{(?<name>[a-zA-Z]+)}",
                new GetHandler(httpContext => new UserController()
                .Details(httpContext.Request.UrlParameters["name"])));
        }
    }
}