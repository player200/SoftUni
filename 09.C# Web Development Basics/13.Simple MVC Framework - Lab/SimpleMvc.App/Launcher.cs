namespace SimpleMvc.App
{
    using WebServer;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using SimpleMvc.Data;

    public class Launcher
    {
        public static void Main()
        {
            var server = new WebServer(8000, new ControllerRouter());

            InitializeDatabase();

            MvcEngine.Run(server);
        }

        private static void InitializeDatabase()
        {
            using (var context = new SimpleMvcDbContext())
            {
            }
        }
    }
}