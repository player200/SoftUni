namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Data.Models;
    using LearningSystem.Service;
    using LearningSystem.Service.Models;
    using LearningSystem.Web.Infrastructures.Extentions;
    using LearningSystem.Web.Models.Courses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CoursesController : Controller
    {
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;

        public CoursesController(
            ICourseService courses,
            UserManager<User> userManager)
        {
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel
            {
                Course = await this.courses.ByIdAsync<CourseDetailsServiceModel>(id)
            };

            if (model.Course == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = this.userManager.GetUserId(User);

                model.IsUserSignIn = await this.courses.UserIsSignInCourse(id, userId);
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignIn(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SignInUser(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("You successfully enrrolled in this course!");

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SignOutUser(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("You successfully leaved this course!");

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}