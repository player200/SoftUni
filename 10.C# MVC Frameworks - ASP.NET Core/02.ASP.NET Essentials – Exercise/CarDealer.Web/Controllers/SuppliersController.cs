namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        public readonly ISuppliersService suppliers;

        public SuppliersController(ISuppliersService suppliers)
        {
            this.suppliers = suppliers;
        }

        [HttpGet("suppliers/local")]
        public IActionResult Local()
        {
            var result = this.suppliers.Local();

            return View(result);
        }

        [HttpGet("suppliers/importers")]
        public IActionResult Importers()
        {
            var result = this.suppliers.Importers();

            return View(result);
        }
    }
}