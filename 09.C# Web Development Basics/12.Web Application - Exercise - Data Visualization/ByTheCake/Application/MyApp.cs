namespace ByTheCake.Application
{
    using ByTheCake.Application.Controllers;
    using ByTheCake.Application.Resources.Data;
    using ByTheCake.Application.ViewModel.Account;
    using ByTheCake.Application.ViewModel.Products;
    using ByTheCake.Server.Contracts;
    using ByTheCake.Server.Routing.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class MyApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new ByTheCakeDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add("/register");
            appRouteConfig.AnonymousPaths.Add("/login");

            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakeController().Add());

            appRouteConfig
                 .Post(
                     "/add",
                     req => new CakeController().Add(
                         new AddProductViewModel
                         {
                             Name = req.FormData["name"],
                             Price = decimal.Parse(req.FormData["price"]),
                             ImageUrl = req.FormData["imageUrl"]
                         }));

            appRouteConfig
                .Get("/search", 
                    req => new CakeController().Search(req));

            appRouteConfig
                .Get(
                    "/cakes/{(?<id>[0-9]+)}",
                    req => new CakeController()
                        .Details(int.Parse(req.UrlParameters["id"])));

            appRouteConfig
                .Get(
                    "/register",
                    req => new AccountController().Register());

            appRouteConfig
                .Post(
                    "/register",
                    req => new AccountController().Register(
                        req,
                        new RegisterUserViewModel
                        {
                            Username = req.FormData["username"],
                            Password = req.FormData["password"],
                            ConfirmPassword = req.FormData["confirm-password"]
                        }));

            appRouteConfig
                .Get("/login",
                    req => new AccountController().Login());

            appRouteConfig
                 .Post(
                     "/login",
                     req => new AccountController().Login(
                         req,
                         new LoginViewModel
                         {
                             Username = req.FormData["username"],
                             Password = req.FormData["password"]
                         }));

            appRouteConfig
                .Get(
                    "/profile",
                    req => new AccountController().Profile(req));

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