namespace WebServer.Server.Http.Contracts
{
    using System.Collections.Generic;
    using WebServer.Server.Enums;

    public interface IHttpRequest
    {
        Dictionary<string,string> FormData { get; }

        HttpHeaderCollection HeaderCollection { get; }

        string Path { get; }

        Dictionary<string, string> QueryParameters { get; }

        HttpRequestMethod RequestMethod { get; }

        string Url { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}