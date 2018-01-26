namespace BookShop.Api.Controllers
{
    using BookShop.Api.Infrastructures.Extentions;
    using BookShop.Api.Models.Book;
    using BookShop.Service;
    using Microsoft.AspNetCore.Mvc;

    public class BooksController : BaseController
    {
        private readonly IBookService books;
        private readonly IAuthorService author;

        public BooksController(
            IBookService books,
            IAuthorService author)
        {
            this.books = books;
            this.author = author;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.OkOrNotFound(this.books.Details(id));
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string search = "")
        {
            return this.Ok(this.books.BooksBySearch(search));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateBookRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this.author.Exists(model.AuthorId))
            {
                return BadRequest("Author don't exist.");
            }

            var id = this.books.Create(
                model.Title,
                model.Descrtioption,
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId,
                model.Categories);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EditBooksRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this.books.Exists(model.Id))
            {
                return BadRequest("Book don't exist.");
            }

            if (!this.author.Exists(model.AuthorId))
            {
                return BadRequest("Author don't exist.");
            }

            var bookId = this.books.Edit(
                model.Id,
                model.Title,
                model.Descrtioption,
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId);

            return Ok(bookId);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!this.books.Exists(id))
            {
                return BadRequest("Book don't exist.");
            }

            var bookId = this.books.Delete(id);

            return Ok(bookId);
        }
    }
}