namespace ByTheCake.Server.Http.Responce
{
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.Exeptions;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}