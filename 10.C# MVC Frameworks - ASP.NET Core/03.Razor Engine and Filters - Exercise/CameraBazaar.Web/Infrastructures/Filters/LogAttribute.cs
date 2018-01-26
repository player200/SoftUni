namespace CameraBazaar.Web.Infrastructures.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;

    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            using (var writer=new StreamWriter("log.txt",true))
            {
                var dateTime = DateTime.UtcNow;
                var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
                var userName = context.HttpContext.User?.Identity?.Name ?? "Anonymous";
                var controller = context.Controller.GetType().Name;
                var action = context.RouteData.Values["action"];

                var logMassage = $"{dateTime} – {ipAddress} – {userName} – {context}.{action}";

                if (context.Exception!=null)
                {
                    var exceptionType = context.Exception.GetType().Name;
                    var exceptionMessage = context.Exception.Message;

                    logMassage = $"[!] {logMassage} - {exceptionType} – {exceptionMessage}";
                }

                writer.WriteLine(logMassage);
            }
        }
    }
}