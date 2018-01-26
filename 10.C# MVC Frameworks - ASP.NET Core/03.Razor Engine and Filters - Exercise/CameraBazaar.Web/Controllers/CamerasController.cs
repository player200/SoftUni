namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services;
    using CameraBazaar.Web.Models.CamerasViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;


    //if program dont build start your database by starting mssql !!!


    public class CamerasController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICameraService camera;

        public CamerasController(ICameraService camera, UserManager<User> userManager)
        {
            this.camera = camera;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddCameraViewModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.camera.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult All()
        {
            return View(this.camera.All());
        }

        public IActionResult Details(string id)
        {
            return View(this.camera.ById(int.Parse(id)));
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var result = this.camera.ById(int.Parse(id));

            if (User.Identity.Name != result.UserName)
            {
                return RedirectToAction(nameof(All));
            }

            return View(new RandomCamModel
            {
                Make = result.Make,
                CameraModel = result.Model,
                Price = result.Price,
                Quantity = result.Quantity,
                MinShutterSpeed = result.MinShutterSpeed,
                MaxShutterSpeed = result.MaxShutterSpeed,
                MinISO = result.MinISO,
                MaxISO = result.MaxISO,
                IsFullFrame = result.IsFullFrame,
                VideoResolution = result.VideoResolution,
                Description = result.Description,
                ImageUrl = result.ImageUrl
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id, RandomCamModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = this.camera.ById(int.Parse(id));

            if (User.Identity.Name != result.UserName)
            {
                return RedirectToAction(nameof(All));
            }

            this.camera.Edit(
                int.Parse(id),
                model.Make,
                model.CameraModel,
                model.Price,
                model.Quantity,
                model.MinShutterSpeed,
                model.MaxShutterSpeed,
                model.MinISO,
                model.MaxISO,
                model.IsFullFrame,
                model.VideoResolution,
                model.Description,
                model.ImageUrl
                );

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var result = this.camera.ById(id);

            return View(new RandomCamModel
            {
                Make = result.Make,
                CameraModel = result.Model,
                Price = result.Price,
                Quantity = result.Quantity,
                MinShutterSpeed = result.MinShutterSpeed,
                MaxShutterSpeed = result.MaxShutterSpeed,
                MinISO = result.MinISO,
                MaxISO = result.MaxISO,
                IsFullFrame = result.IsFullFrame,
                VideoResolution = result.VideoResolution,
                Description = result.Description,
                ImageUrl = result.ImageUrl
            });
        }

        [HttpPost]
        public IActionResult Delete(int id, RandomCamModel model)
        {
            this.camera.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}