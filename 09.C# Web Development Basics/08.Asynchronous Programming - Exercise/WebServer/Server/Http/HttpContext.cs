namespace WebServer.Server.Http
{
    using WebServer.Server.Http.Contracts;

    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(string requestStr)
        {
            this.request = new HttpRequest(requestStr);
        }

        public IHttpRequest Request => this.request;
    }
}