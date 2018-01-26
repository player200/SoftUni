namespace SimpleMvc.Framework.ActionResults
{
    using SimpleMvc.Framework.Contracts;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class NotFoundResult : IActionResult
    {
        public IHttpResponse Invoke()
            => new NotFoundResponse();
    }
}