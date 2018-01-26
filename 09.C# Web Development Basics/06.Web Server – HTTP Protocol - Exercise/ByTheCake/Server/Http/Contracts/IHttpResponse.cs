namespace ByTheCake.Server.Http.Contracts
{
    using ByTheCake.Server.Enums;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection Headers { get; }
    }
}
