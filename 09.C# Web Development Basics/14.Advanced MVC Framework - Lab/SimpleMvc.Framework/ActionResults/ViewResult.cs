namespace SimpleMvc.Framework.ActionResults
{
    using SimpleMvc.Framework.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; set; }

        public IHttpResponse Invoke()
        {
            return new ContentResponse(HttpStatusCode.Ok, this.View.Render());
        }
    }
}