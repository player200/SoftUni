namespace ByTheCake.Server.Http.Contracts
{
    using ByTheCake.Server.Enums;
    using System.Collections.Generic;

    public interface IHttpRequest
    {
        IDictionary<string, string> FormData { get; }

        IHttpHeaderCollection Headers { get; }
       
        string Path { get; }

        HttpRequestMethod Method { get; }

        string Url { get; }

        IDictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}
