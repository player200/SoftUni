namespace BookShop.Api.Controllers
{
    using BookShop.Api.Infrastructures.Extentions;
    using BookShop.Api.Models.Author;
    using BookShop.Service;
    using Microsoft.AspNetCore.Mvc;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.OkOrNotFound(this.authors.Details(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]AuthorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = this.authors.Create(
                model.FirstName,
                model.LastName);

            return Ok(id);
        }

        [HttpGet("{id}/books")]
        public IActionResult GetBooks(int id)
        {
            return this.Ok(this.authors.BooksById(id));
        }
    }
}