namespace ByTheCake.Server.Http
{
    using System;

    public class HttpHeader
    {
        public const string ContentType = "Content-Type";
        public const string Host = "Host";
        public const string Location = "Location";
        public const string Cookie = "Cookie";
        public const string SetCookie = "Set-Cookie";

        public HttpHeader(string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}