namespace ByTheCake.Server.Exeptions
{
    using System;

    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            : base(message)
        {
        }
    }
}