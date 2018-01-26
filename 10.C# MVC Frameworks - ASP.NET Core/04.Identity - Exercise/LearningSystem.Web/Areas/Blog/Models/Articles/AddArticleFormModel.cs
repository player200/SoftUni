namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using LearningSystem.Data;
    using System.ComponentModel.DataAnnotations;

    public class AddArticleFormModel
    {
        [Required]
        [MinLength(DataConstants.ArticleTitleMinLength)]
        [MaxLength(DataConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}