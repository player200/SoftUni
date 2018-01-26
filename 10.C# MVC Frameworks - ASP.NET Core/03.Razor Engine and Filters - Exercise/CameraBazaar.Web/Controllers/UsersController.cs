namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Services;
    using CameraBazaar.Web.Models.UsersViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUserService user;

        public UsersController(IUserService user)
        {
            this.user = user;
        }

        [Authorize]
        [HttpGet("/users/profile/{username}")]
        public IActionResult Profile(string username)
        {
            return View(this.user.ById(username));
        }

        [Authorize]
        [HttpGet("/users/edit/{username}")]
        public IActionResult Edit(string username)
        {
            var result = this.user.ById(username);

            if (User.Identity.Name != result.UserName)
            {
                return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
            }

            return View(new CreateUserModel
            {
                Email = result.Email,
                Phone = result.Phone,
                LastTimeLoged=result.LastTimeLoged
            });
        }

        [Authorize]
        [HttpPost("/users/edit/{username}")]
        public IActionResult Edit(string username, CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (User.Identity.Name != username)
            {
                return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
            }

            this.user.Edit(
                username,
                model.Email,
                model.Phone
                );

            return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
        }
    }
}