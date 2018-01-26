namespace ByTheCake.Server.Http
{
    using ByTheCake.Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> values;

        public HttpSession(string id)
        {
            this.Id = id;
            this.values = new Dictionary<string, object>();
        }

        public string Id { get; private set; }

        public void Add(string key, object value)
        {
            this.values[key] = value;
        }

        public void Clear()
        {
            this.values.Clear();
        }

        public object Get(string key)
        {
            if (!this.values.ContainsKey(key))
            {
                return null;
            }

            return this.values[key];
        }

        public T Get<T>(string key)
            => (T)this.Get(key);
    }
}