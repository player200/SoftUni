namespace ByTheCake.GameStore.Controllers
{
    using ByTheCake.GameStore.Data;
    using ByTheCake.GameStore.Data.Models;
    using ByTheCake.GameStore.Survices;
    using ByTheCake.GameStore.Survices.Contracts;
    using ByTheCake.GameStore.ViewModels.Admin;
    using ByTheCake.Server.Http.Contracts;
    using System;
    using System.Linq;

    public class AdminController : BaseController
    {
        private const string AddGameView = @"admin\add-game";
        private const string ListGamesView = @"admin\list-games";
        private const string EditGameView = @"admin\edit-game";

        private readonly IGameService games;

        public AdminController(IHttpRequest request)
            : base(request)
        {
            this.games = new GameService();
        }

        public IHttpResponse Add()
        {
            if (this.Authentication.IsAdmin)
            {
                return this.FileViewResponse(AddGameView);
            }
            else
            {
                return this.RedirectResponse(HomePath);
            }
        }

        public IHttpResponse Add(AdminAddGameViewModel model)
        {
            if (!this.Authentication.IsAdmin)
            {
                return this.RedirectResponse(HomePath);
            }

            if (!this.ValidateModel(model))
            {
                return this.Add();
            }

            this.games.Create(
                model.Title,
                model.Description,
                model.Image,
                model.Price,
                model.Size,
                model.VideoId,
                model.ReleaseDate.Value);

            return this.RedirectResponse("/admin/games/list");
        }

        public IHttpResponse List()
        {
            if (!this.Authentication.IsAdmin)
            {
                return this.RedirectResponse(HomePath);
            }

            var result = this.games
                .All()
                .Select(g => $@"<tr>
                                    <td>{g.Id}</td>
                                    <td>{g.Name}</td>
                                    <td>{g.Size:F2} GB</td>
                                    <td>{g.Price:F2} &euro;</td>
                                    <td>
                                        <a class=""btn btn-warning"" href=""/admin/games/edit-game/{g.Id}"">Edit</a>
                                        <a class=""btn btn-danger"" href=""/admin/games/delete/{g.Id}"">Delete</a>
                                    </td>
                                </tr>");

            var gamesAsHtml = string.Join(Environment.NewLine, result);

            this.ViewData["games"] = gamesAsHtml;

            return this.FileViewResponse(ListGamesView);
        }

        public IHttpResponse Edit()
        {
        //    int id = int.Parse(this.Request.UrlParameters["id"]);
            if (this.Authentication.IsAdmin)
            {
                return this.FileViewResponse(EditGameView);
            }
            else
            {
                return this.RedirectResponse(HomePath);
            }
        }
    }
}