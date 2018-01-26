namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using LearningSystem.Data.Models;
    using LearningSystem.Service.Admin;
    using LearningSystem.Web.Areas.Admin.Models.Users;
    using LearningSystem.Web.Infrastructures.Extentions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService admin;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(
            IAdminUserService admin,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.admin = admin;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.admin.AllAsync();
            var roles = this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();

            var model = new AdminUserListingViewModel
            {
                Users = users,
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to {model.Role} role.");
            return RedirectToAction(nameof(Index));
        }
    }
}