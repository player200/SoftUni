namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Infrastructures;
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.Http.Contracts;
    using ByTheCake.Server.Http.Responce;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LoginFormController : BaseController
    {
        public IHttpResponse Login() => this.FileViewResponse("/login", new Dictionary<string, string>
        {
            ["showResult"] = "none"
        });

        public IHttpResponse Login(string username, string password)
        {
            var result = $"Hi {username}, your password is {password}";

            return this.FileViewResponse(@"/login", new Dictionary<string, string>
            {
                ["result"] = result,
                ["showResult"] = "block"
            });
        }

        public IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
        {
            var result = this.ProcessFileHtml(fileName);

            if (values != null && values.Any())
            {
                foreach (var value in values)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            var result = File.ReadAllText(string.Format(DefaultPath, fileName));

            return result;
        }
    }
}