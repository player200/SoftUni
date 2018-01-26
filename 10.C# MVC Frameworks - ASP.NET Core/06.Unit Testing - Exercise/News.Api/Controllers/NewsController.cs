namespace News.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using News.Api.Models.News;
    using News.Service;

    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this.news.All());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!this.news.Exists(id))
            {
                return NotFound();
            }

            return this.Ok(this.news.ById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateNewsRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var result = this.news.Create(
                model.Title,
                model.Content,
                model.PublishDate);
            
            return this.CreatedAtAction("GetById", new { id = result }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EditNewsRequestModel model)
        {
            if (!this.news.Exists(id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            return this.Ok(this.news.Edit(
                id,
                model.Title,
                model.Content,
                model.PublishDate));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!this.news.Exists(id))
            {
                return this.BadRequest();
            }

            return this.Ok(this.news.Delete(id));
        }
    }
}