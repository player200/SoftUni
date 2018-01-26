namespace _02.ValidateURL
{
    using System;
    using System.Net;

    public class Program
    {
        public static void Main()
        {
            string inputUrl = Console.ReadLine();
            string transformedUrl = WebUtility.UrlDecode(inputUrl);

            try
            {
                Uri url = new Uri(transformedUrl);

                if ((url.Scheme == "http" && url.Port >= 443)
                    || (url.Scheme == "https" && url.Port < 443)
                    || string.IsNullOrEmpty(url.Scheme)
                    || string.IsNullOrEmpty(url.Host))
                {
                    Console.WriteLine($"Invalid URL");
                }

                else
                {
                    Console.WriteLine($"Protocol: {url.Scheme}");
                    Console.WriteLine($"Host: {url.Host}");
                    Console.WriteLine($"Port: {url.Port}");
                    Console.WriteLine($"Path: {url.AbsolutePath}");

                    if (!string.IsNullOrEmpty(url.Query))
                    {
                        Console.WriteLine($"Qyery: {url.Query}");
                    }

                    if (!string.IsNullOrEmpty(url.Fragment))
                    {
                        Console.WriteLine($"Fragment: {url.Fragment.Remove(0, 1)}");
                    }

                }

            }

            catch (Exception)
            {
                Console.WriteLine($"Invalid URL");
            }
        }
    }
}