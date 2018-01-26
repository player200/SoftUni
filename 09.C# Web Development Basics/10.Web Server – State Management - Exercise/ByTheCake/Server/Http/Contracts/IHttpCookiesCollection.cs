namespace ByTheCake.Server.Http.Contracts
{
    using System.Collections.Generic;

    public interface IHttpCookiesCollection : IEnumerable<HttpCookie>
    {
        void Add(HttpCookie cookie);

        void Add(string key, string value);

        bool ContainsKey(string key);

        HttpCookie Get(string key);
    }
}