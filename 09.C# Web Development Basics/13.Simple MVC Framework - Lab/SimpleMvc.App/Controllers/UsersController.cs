namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Data;
    using SimpleMvc.Domain;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Contracts.Generic;
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
        public IActionResult<AllUsernamesViewModel> All()
        {
            Dictionary<int, string> usersAndIds;

            using (var db = new SimpleMvcDbContext())
            {
                usersAndIds = new Dictionary<int, string>();

                var usersFromDb = db
                    .Users
                    .Select(u => new
                    {
                        u.Id,
                        u.Username
                    });

                foreach (var userFromDb in usersFromDb)
                {
                    usersAndIds[userFromDb.Id] = userFromDb.Username;
                }
            }

            var viewModel = new AllUsernamesViewModel
            {
                UsersWithIds = usersAndIds
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
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

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
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
    }
}