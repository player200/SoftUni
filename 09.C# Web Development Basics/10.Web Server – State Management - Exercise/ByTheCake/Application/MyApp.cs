namespace ByTheCake.Application
{
    using ByTheCake.Application.Controllers;
    using ByTheCake.Server.Contracts;
    using ByTheCake.Server.Routing.Contracts;

    public class MyApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakeController().Add());

            appRouteConfig
                .Post("/add",
                    req => new CakeController().Add(req.FormData["name"], req.FormData["price"]));

            appRouteConfig
                .Get("/search", 
                    req => new CakeController().Search(req));

            appRouteConfig
                .Get("/login",
                    req => new AccountController().Login());

            appRouteConfig
                .Post("/login",
                    req => new AccountController().Login(req));

            appRouteConfig
                .Post("/logout",
                    req => new AccountController().Logout(req));
            
            appRouteConfig
                .Get(
                    "/cart",
                    req => new ShoppingController().ShowCart(req));

            appRouteConfig
                .Get(
                    "/shopping/add/{(?<id>[0-9]+)}",
                    req => new ShoppingController().AddToCart(req));

            appRouteConfig
                .Post(
                    "/shopping/finish-order",
                    req => new ShoppingController().FinishOrder(req));

            //Those are for other tasks need to be removed in other folder - For me
            //appRouteConfig
            //    .Get("/calculator", req => new CalculatorController().Calculate());

            //appRouteConfig
            //    .Post("/calculator",
            //        req => new CalculatorController().Calculate(req.FormData["firstNum"], req.FormData["operation"], req.FormData["secondNum"]));

            //appRouteConfig
            //    .Get("/login", req => new LoginFormController().Login());

            //appRouteConfig
            //    .Post("/login",
            //        req => new LoginFormController().Login(req.FormData["username"], req.FormData["password"]));

            //appRouteConfig.Get(
            //   "/testsession",
            //   req => new HomeController().SessionTest(req));
        }
    }
}