﻿namespace SimpleMvc.App.Views.Users
{
    using SimpleMvc.Framework.Contracts;

    public class Register : IRenderable
    {
        public string Render()
        {
            return
                "<a href =\"/home/index\">< Home</a>" +
                "<h3>Register new user</h3>" +
                "<form action=\"register\" method=\"POST\">" +
                "Username:" +
                "<input type=\"text\" name=\"Username\" placeholder=\"Username\"/>" +
                "<br />" +
                "Password:" +
                "<input type=\"password\" name=\"Password\" placeholder=\"Password\"/>" +
                "<br />" +
                "<input type=\"submit\" value=\"Register\" />" +
                "</form>";
        }
    }
}