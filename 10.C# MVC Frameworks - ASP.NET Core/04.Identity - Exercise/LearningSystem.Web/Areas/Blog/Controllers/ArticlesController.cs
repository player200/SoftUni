namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using LearningSystem.Data.Models;
    using LearningSystem.Service.Blog;
    using LearningSystem.Web.Areas.Blog.Models.Articles;
    using LearningSystem.Web.Controllers;
    using LearningSystem.Web.Infrastructures.Extentions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IBlogArticleService blog;

        public ArticlesController(
            UserManager<User> userManager,
            IBlogArticleService blog)
        {
            this.userManager = userManager;
            this.blog = blog;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddArticleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.blog.Create(
                model.Title,
                model.Content,
                DateTime.UtcNow,
                this.userManager.GetUserId(User));

            TempData.AddSuccessMessage($"Article {model.Title} created successfully!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchtext)
        {
            if (searchtext == null)
            {
                return View(new SearchArticlesViewModel
                {
                    Articles = await this.blog.AllAsync()
                });
            }

            return View(new SearchArticlesViewModel
            {
                Articles = await this.blog.FindAsync(searchtext)
            });
        }
    }
}