namespace FluffyDuffyMunchkinCats.Middleware
{
    using FluffyDuffyMunchkinCats.Infrastructures;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class HtmlContentTypeMiddleWare
    {
        private readonly RequestDelegate next;

        public HtmlContentTypeMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HttpHeader.ContentType, "text/html");

            return this.next(context);
        }
    }
}