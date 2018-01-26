namespace WebServer
{
    using WebServer.Application;
    using WebServer.Server;
    using WebServer.Server.Contracts;
    using WebServer.Server.Routing;
    using WebServer.Server.Routing.Contracts;

    public class Launcher : IRunnable
    {
        private WebServers webServer;

        private static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new WebServers(8230, routeConfig);
            this.webServer.Run();
        }
    }
}