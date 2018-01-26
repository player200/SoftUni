namespace WebServer.Server.Http.Response
{
    using WebServer.Server.Contracts;
    using WebServer.Server.Enums;

    public class ViewResponse : HttpResponse
    {
        public ViewResponse(HttpStatusCode responseCode, IView view) : base(responseCode, view)
        {
        }
    }
}