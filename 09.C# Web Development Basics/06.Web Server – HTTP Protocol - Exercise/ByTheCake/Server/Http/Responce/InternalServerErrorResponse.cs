namespace ByTheCake.Server.Http.Responce
{
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.Exeptions;
    using System;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}