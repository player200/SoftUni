namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Application.Views;
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.Http.Contracts;
    using ByTheCake.Server.Http.Responce;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class CalculatorController
    {
        private const string DefaultPath = @".\Application\Resources\{0}.html";

        public IHttpResponse Calculate() => this.FileViewResponse("/calculator", new Dictionary<string, string>
        {
            ["showResult"] = "none"
        });

        public IHttpResponse Calculate(string firstNum, string operation, string secondNum)
        {
            string result = "";
            double numOne = double.Parse(firstNum);
            double numTwo = double.Parse(secondNum);

            switch (operation[0])
            {
                case '+':
                    result = (numOne + numTwo).ToString();
                    break;
                case '-':
                    result = (numOne - numTwo).ToString();
                    break;
                case '*':
                    result = (numOne * numTwo).ToString();
                    break;
                case '/':
                    result = (numOne / numTwo).ToString();
                    break;
                default:
                    result = "Invalid Sign";
                    break;
            }

            return this.FileViewResponse(@"/calculator", new Dictionary<string, string>
            {
                ["result"] = result,
                ["showResult"] = "block"
            });
        }

        public IHttpResponse FileViewResponse(string fileName)
        {
            string result = this.ProcessFileHtml(fileName);

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        public IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
        {
            string result = this.ProcessFileHtml(fileName);

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
            string result = File.ReadAllText(string.Format(DefaultPath, fileName));

            return result;
        }
    }
}