namespace ByTheCake
{
    using ByTheCake.Application;
    using ByTheCake.Server;
    using ByTheCake.Server.Contracts;
    using ByTheCake.Server.Routing;

    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            var mainApplication = new MyApp();
            mainApplication.InitializeDatabase();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}