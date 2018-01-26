namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Data.Models;
    using LearningSystem.Service;
    using LearningSystem.Service.Models;
    using LearningSystem.Web.Models.Trainers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainersController : Controller
    {
        private readonly ITrainerService trainers;
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;

        public TrainersController(
            ITrainerService trainers,
            ICourseService courses,
            UserManager<User> userManager)
        {
            this.trainers = trainers;
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Courses()
        {
            var trainerId = this.userManager.GetUserId(User);
            return View(await this.trainers.ByTrainer(trainerId));
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return NotFound();
            }

            return View(new StudentsInCourseViewModel
            {
                Students = await this.trainers.StudentsInCourseAsync(id),
                Courses = await this.courses.ByIdAsync<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> GradesStrudent(int id, string studentId, Grade grade)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return NotFound();
            }

            var success = await this.trainers.AddGrade(id, studentId, grade);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Students), new { id });
        }
    }
}