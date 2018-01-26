namespace BookShop.Api.Controllers
{
    using BookShop.Api.Infrastructures.Extentions;
    using BookShop.Api.Models.Category;
    using BookShop.Service;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.OkOrNotFound(this.categories.All());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.OkOrNotFound(this.categories.Details(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateCategoryRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this.categories.Exists(model.Name))
            {
                return BadRequest("Author don't exist.");
            }

            var id = this.categories.Create(model.Name);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EditCategoryRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this.categories.Exists(model.Name))
            {
                return BadRequest("Category don't exist.");
            }

            var categoryId = this.categories.Edit(
                model.Id,
                model.Name);

            return Ok(categoryId);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!this.categories.ExistsById(id))
            {
                return BadRequest("Category don't exist.");
            }

            var categoryId = this.categories.Delete(id);

            return Ok(categoryId);
        }
    }
}