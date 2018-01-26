namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private readonly ISaleService sale;

        public SalesController(ISaleService sale)
        {
            this.sale = sale;
        }

        [HttpGet("sales")]
        [Route("sales/all")]
        public IActionResult All()
        {
            var result = this.sale.SalesAll();

            return View(result);
        }

        [HttpGet("sales/{id}")]
        [Route("sales/byid")]
        public IActionResult ById(string id)
        {
            var result = this.sale.SalesById(int.Parse(id));

            return View(result);
        }

        [HttpGet("sales/discounted")]
        [Route("sales/discounted")]
        public IActionResult Discounted()
        {
            var result = this.sale.SalesDiscounted();

            return View(result);
        }

        [HttpGet("sales/discounted/{discount}")]
        [Route("sales/discountedby")]
        public IActionResult DiscountedBy(string discount)
        {
            var result = this.sale.SalesDiscounted(double.Parse(discount));

            return View(result);
        }
    }
}