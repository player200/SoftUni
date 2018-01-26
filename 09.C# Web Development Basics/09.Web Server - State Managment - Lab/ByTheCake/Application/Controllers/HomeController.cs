namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Application.Views;
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.Http;
    using ByTheCake.Server.Http.Contracts;
    using ByTheCake.Server.Http.Responce;
    using System;

    public class HomeController : Controller
    {
        public IHttpResponse Index()
        {
            var index= this.FileViewResponse(@"index");

            index.Cookies.Add(new HttpCookie("lang","en"));

            return index;
        }

        public IHttpResponse About()
        {
            return this.FileViewResponse(@"about");
        }

        public IHttpResponse SessionTest(IHttpRequest req)
        {
            var session = req.Session;

            const string sessionDateKey = "saved_date";

            if (session.Get(sessionDateKey) == null)
            {
                session.Add(sessionDateKey, DateTime.UtcNow);
            }

            return new ViewResponse(
                HttpStatusCode.Ok,
                new SessionTestView(session.Get<DateTime>(sessionDateKey)));
        }
    }
}