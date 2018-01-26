namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Services.Models;
    using CarDealer.Web.Models.Customers;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customer;

        public CustomersController(ICustomerService customer)
        {
            this.customer = customer;
        }

        [Route("customers/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("customers/create")]
        public IActionResult Create(CreateCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this.customer.Create(
                model.Name,
                model.BithDate,
                model.IsYoungDrivert
                );

            return RedirectToAction(nameof(All), new { order = OrderedType.Ascending });
        }

        [Route("customer/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var result = this.customer.ById(id);

            return View(new CreateCustomerModel
            {
                Name = result.Name,
                BithDate = result.BirthDate,
                IsYoungDrivert = result.IsYoungDriver
            });
        }

        [HttpPost]
        [Route("customer/edit/{id}")]
        public IActionResult Edit(int id, CreateCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customers = this.customer.Exists(id);

            if (!customers)
            {
                return NotFound();
            }

            this.customer.Edit(
                id,
                model.Name,
                model.BithDate,
                model.IsYoungDrivert
                );

            return RedirectToAction(nameof(All), new { order = OrderedType.Ascending });
        }

        [HttpGet("customers/all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirectory = order.ToLower() == "descending" ?
                OrderedType.Descending
                : OrderedType.Ascending;

            var customer = this.customer.OrderedCustomers(orderDirectory);

            return View(new AllCustomersModel
            {
                Customers = customer,
                Ordered = orderDirectory
            });
        }

        [HttpGet("customers/{id}")]
        [Route("customers/info")]
        public IActionResult Info(string id)
        {
            var result = this.customer.CustomerInfo(int.Parse(id));

            return View(result);
        }
    }
}