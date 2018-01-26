namespace ByTheCake.Server.Http
{
    using ByTheCake.Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class HttpCookieCollection : IHttpCookiesCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            this.cookies[cookie.Key] = cookie;
        }

        public void Add(string key, string value)
        {
            this.Add(new HttpCookie(key, value));
        }

        public bool ContainsKey(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie Get(string key)
        {
            if (!this.cookies.ContainsKey(key))
            {
                throw new InvalidOperationException($"The given key {key} is not present in the cookies collection.");
            }

            return this.cookies[key];
        }

        public IEnumerator<HttpCookie> GetEnumerator()
            => this.cookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.cookies.Values.GetEnumerator();
    }
}