namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Server.Http.Contracts;

    public class HomeController : Controller
    {
        public IHttpResponse Index()
        {
            return this.FileViewResponse(@"index");
        }

        public IHttpResponse About()
        {
            return this.FileViewResponse(@"about");
        }
    }
}