namespace _01.URLDecode
{
    using System;
    using System.Net;

    public class Program
    {
        public static void Main()
        {
            string inputUrl = Console.ReadLine();
            string transformedUrl = WebUtility.UrlDecode(inputUrl);
            Console.WriteLine(transformedUrl);
        }
    }
}