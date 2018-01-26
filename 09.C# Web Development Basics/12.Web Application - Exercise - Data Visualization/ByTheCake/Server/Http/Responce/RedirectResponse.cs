namespace ByTheCake.Server.Http.Responce
{
    using ByTheCake.Server.Enums;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            this.StatusCode = HttpStatusCode.Found;

            this.Headers.Add(HttpHeader.Location, redirectUrl);
        }
    }
}