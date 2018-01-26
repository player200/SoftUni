namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using LearningSystem.Data.Models;
    using LearningSystem.Service.Admin;
    using LearningSystem.Web.Areas.Admin.Models.Courses;
    using LearningSystem.Web.Controllers;
    using LearningSystem.Web.Infrastructures.Extentions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminCourseService course;

        public CoursesController(
            UserManager<User> userManager,
            IAdminCourseService course)
        {
            this.userManager = userManager;
            this.course = course;
        }

        public async Task<IActionResult> Create()
        {
            return View(new AddCourseFormModel
            {
                Trainers = await this.GetTraineres()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCourseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Trainers = await this.GetTraineres();
                return View(model);
            }

            await this.course.Create(
                model.Name,
                model.Description,
                model.StartDate,
                model.EndDate,
                model.TrainerId);

            TempData.AddSuccessMessage($"Couse {model.Name} created successfully!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        private async Task<IEnumerable<SelectListItem>> GetTraineres()
        {
            var trainers = await this.userManager
                .GetUsersInRoleAsync(WebConstants.TrainerRole);

            var trainersToListItem = trainers
                .Select(t => new SelectListItem
                {
                    Text = t.UserName,
                    Value = t.Id
                })
                .ToList();

            return trainersToListItem;
        }
    }
}