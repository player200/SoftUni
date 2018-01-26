namespace ByTheCake.Application.Views
{
    using ByTheCake.Server.Contracts;
    using System;

    public class SessionTestView : IView
    {
        private readonly DateTime dateTime;

        public SessionTestView(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public string View()
        {
            return $"<h1>Saved date: {dateTime}</h1>";
        }
    }
}