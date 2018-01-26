namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Services.Models;
    using CarDealer.Web.Models.Parts;
    using Microsoft.AspNetCore.Mvc;

    public class PartsController : Controller
    {
        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        public IActionResult All()
        {
            return View(this.parts.AllParts());
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(PartsToDbModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var supplierExists = this.parts.Exists(model.SupplierName);

            if (!supplierExists)
            {
                return this.NotFound();
            }

            this.parts.Create(model.Name, model.Price, model.SupplierName);
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var result = this.parts.ById(id);

            return View(new CreatePartsModel
            {
                Name = result.Name,
                Price = result.Price,
                Quantity = result.Quantity
            });
        }

        [HttpPost]
        public IActionResult Delete(int id, CreatePartsModel model)
        {
            this.parts.Delete(id);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var result = this.parts.ById(id);

            return View(new CreatePartsModel
            {
                Name = result.Name,
                Price = result.Price,
                Quantity = result.Quantity
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, CreatePartsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.parts.Edit(
                id,
                model.Name,
                model.Price,
                model.Quantity
                );

            return RedirectToAction(nameof(All));
        }
    }
}