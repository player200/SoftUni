namespace ModPanel.App.Controllers
{
    using ModPanel.App.Data;
    using ModPanel.App.Data.Models;
    using ModPanel.App.Services;
    using ModPanel.App.Services.Contracts;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;
    using System.Linq;

    public abstract class BaseController : Controller
    {
        private ILogService log;

        protected BaseController()
        {
            this.log = new LogService();
            this.ViewModel["anonymousDisplay"] = "flex";
            this.ViewModel["userDisplay"] = "none";
            this.ViewModel["adminDisplay"] = "none";
            this.ViewModel["show-error"] = "none";
        }

        protected User Profile { get; private set; }

        protected bool IsAdmin => this.User.IsAuthenticated && this.Profile.IsAdmin;

        protected void ShowError(string error)
        {
            this.ViewModel["show-error"] = "block";
            this.ViewModel["error"] = error;
        }

        protected IActionResult RedirectToHome()
        {
            return this.Redirect("/");
        }

        protected IActionResult RedirectToLogin()
        {
            return this.Redirect("/users/login");
        }

        protected void Log(LogType type, string additionalInformation)
            => this.log.Create(
                this.Profile.Email,
                type,
                additionalInformation);

        protected override void InitializeController()
        {
            base.InitializeController();

            if (this.User.IsAuthenticated)
            {
                this.ViewModel["anonymousDisplay"] = "none";
                this.ViewModel["userDisplay"] = "flex";

                using (var db = new ModPanelDbContext())
                {
                    this.Profile = db
                        .Users
                        .First(u => u.Email == this.User.Name);

                    if (this.Profile.IsAdmin)
                    {
                        this.ViewModel["adminDisplay"] = "flex";
                    }
                }
            }
        }
    }
}