namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Application.Model;
    using ByTheCake.Server.Http.Contracts;
    using System;
    using System.Linq;

    public class CakeController : Controller
    {
        private readonly CakesToAdd data;

        public CakeController()
        {
            this.data = new CakesToAdd();
        }

        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";

            return this.FileViewResponse(@"add");
        }

        public IHttpResponse Add(string name, string price)
        {
            var cake = new Cake
            {
                Name = name,
                Price = decimal.Parse(price)
            };

            this.data.Add(name, price);

            this.ViewData["name"] = name;
            this.ViewData["price"] = price;
            this.ViewData["showResult"] = "block";

            return this.FileViewResponse(@"add");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string searchTermKey = "searchTerm";

            var urlParameters = req.UrlParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData["searchTerm"] = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = urlParameters[searchTermKey];

                this.ViewData["searchTerm"] = searchTerm;

                var savedCakesDivs = this.data
                    .All()
                    .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
                    .Select(c => $@"<div>{c.Name} - ${c.Price:F2} </div>");
                var results = "No cakes found";

                if (savedCakesDivs.Any())
                {
                    results = string.Join(Environment.NewLine, savedCakesDivs);
                }

                this.ViewData["results"] = results;
            }

            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            return this.FileViewResponse(@"search");
        }
    }
}