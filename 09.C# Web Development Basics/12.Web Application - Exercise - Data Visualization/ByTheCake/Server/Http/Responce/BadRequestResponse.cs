namespace ByTheCake.Server.Http.Responce
{
    using ByTheCake.Server.Enums;

    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }
    }
}