namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Data;
    using SimpleMvc.Domain;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;
    using System.Collections.Generic;
    using System.Linq;
    using WebServer.Exceptions;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            using (var db = new SimpleMvcDbContext())
            {
                if (db.Users.Any(u => u.Username == model.Username))
                {
                    throw new BadRequestException("Username is already in use.");
                }

                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password
                };


                db.Users.Add(user);
                db.SaveChanges();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel loginUserBinding)
        {
            using (var db=new SimpleMvcDbContext())
            {
                var foundUser = db.Users
                    .FirstOrDefault(u => u.Username == loginUserBinding.Username);

                if (foundUser == null)
                {
                    return this.RedirectToAction("/users/login");
                }

                db.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return this.RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction("/users/login");
            }

            Dictionary<int, string> usersAndIds=new Dictionary<int, string>();

            using (var db=new SimpleMvcDbContext())
            {
                usersAndIds = db.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            this.Model["users"] =
                usersAndIds.Any()
                    ? string.Join(string.Empty, usersAndIds.Select(
                        u => $"<li><a href=\"/users/profile?id={u.Key}\">{u.Value}</a></li>"))
                    : string.Empty;

            return this.View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            using (var db = new SimpleMvcDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                var notes = db.Notes.Where(n => n.UserId == user.Id).ToList();

                var viewModel = new UserProfileViewModel
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = notes.Select(
                    n => new NoteViewModel
                    {
                        Title = n.Title,
                        Content = n.Content
                    })
                };

                this.Model["username"] = string.Join(string.Empty, viewModel.Username);
                this.Model["userId"] = string.Join(string.Empty, viewModel.UserId);
                this.Model["notes"] = viewModel.Notes.Any() ?
                    string.Join(string.Empty, viewModel.Notes.Select(
                        n => $"<li>{n.Title} - {n.Content}</li>"))
                    : string.Empty;

                return View();
            }
        }

        [HttpPost]
        public IActionResult Profile(AddNoteBindingModel model)
        {
            using (var db = new SimpleMvcDbContext())
            {
                var user = db.Users.Find(model.UserId);
                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content,
                };

                user.Notes.Add(note);
                db.SaveChanges();

                return Profile(model.UserId);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.RedirectToAction("/");
        }
    }
}