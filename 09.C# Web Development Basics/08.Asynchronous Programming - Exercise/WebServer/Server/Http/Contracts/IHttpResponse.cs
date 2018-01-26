namespace WebServer.Server.Http.Contracts
{
    using WebServer.Server.Enums;

    public interface IHttpResponse
    {
        HttpHeaderCollection HeaderCollection { get; }

        HttpStatusCode StatusCode { get; }

        string StatusMessage { get; }

        string Response { get; }

        byte[] Data { get; }

        void AddHeader(string key, string value);
    }
}