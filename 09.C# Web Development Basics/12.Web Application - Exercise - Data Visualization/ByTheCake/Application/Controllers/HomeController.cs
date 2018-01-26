namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Application.Views;
    using ByTheCake.Infrastructures;
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.Http.Contracts;
    using ByTheCake.Server.Http.Responce;
    using System;

    public class HomeController : BaseController
    {
        public IHttpResponse Index() => this.FileViewResponse(@"index");

        public IHttpResponse About() => this.FileViewResponse(@"about");

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