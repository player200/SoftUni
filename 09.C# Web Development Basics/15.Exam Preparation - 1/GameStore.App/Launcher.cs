namespace GameStore.App
{
    using GameStore.App.Data;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        static Launcher()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public static void Main()
            => MvcEngine.Run(new WebServer(8000, new ControllerRouter(), new ResourceRouter()));
    }
}