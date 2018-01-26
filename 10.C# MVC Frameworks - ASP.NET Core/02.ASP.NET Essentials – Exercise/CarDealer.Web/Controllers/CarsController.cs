namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Web.Models.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(ICarService cars,IPartService parts)
        {
            this.cars = cars;
            this.parts = parts;
        }

        [HttpGet("cars/{make}")]
        public IActionResult ByMake(string make)
        {
            var result = this.cars.CarsMakeAll(make);

            return View(result);
        }

        [HttpGet("cars/{id}/parts")]
        [Route("cars/parts")]
        public IActionResult Parts(string id)
        {
            var result = this.cars.CarsById(int.Parse(id));

            return View(result);
        }

        [HttpGet("cars/all")]
        [Route("cars/all")]
        public IActionResult All ()
        {
            var result = this.cars.All();

            return View(result);
        }

        [Authorize]
        [HttpGet("cars/create")]
        [Route("cars/create")]
        public IActionResult Create()
        {
            return View(new CreateCarsModel
            {
                AllParts = this.parts
                        .All()
                        .Select(p => new SelectListItem
                        {
                            Text=p.Name,
                            Value=p.Id.ToString()
                        })
            });
        }

        [Authorize]
        [HttpPost("cars/create")]
        [Route("cars/create")]
        public IActionResult Create(CreateCarsModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.AllParts= this.parts
                           .All()
                           .Select(p => new SelectListItem
                           {
                               Text = p.Name,
                               Value = p.Id.ToString()
                           });
                return this.View(model);
            }

            this.cars.Create(model.Make,
                model.CarModel,
                model.TravelledDistance,
                model.SelectedParts);

            return this.RedirectToAction(nameof(All));
        }
    }
}