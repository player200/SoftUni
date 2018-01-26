namespace ModPanel.App.Controllers
{
    using ModPanel.App.Data.Models;
    using ModPanel.App.Models.Posts;
    using ModPanel.App.Services;
    using ModPanel.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class PostsController : BaseController
    {
        private const string CreateError = "<p>Check your form for errors.</p><p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Content must be more than 10 symbols (inclusive).</p>";

        private IPostsServices post;

        public PostsController()
        {
            this.post = new PostsServices();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(PostsModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(CreateError);
                return this.View();
            }

            this.post.Create(
                model.Title,
                model.Content,
                this.Profile.Id);

            if (this.IsAdmin)
            {
                this.Log(LogType.CreatePost, model.Title);
            }

            return this.RedirectToHome();
        }
    }
}