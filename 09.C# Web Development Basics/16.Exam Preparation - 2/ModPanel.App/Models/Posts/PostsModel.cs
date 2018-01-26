namespace ModPanel.App.Models.Posts
{
    using ModPanel.App.Infrastructure.Validation;
    using ModPanel.App.Infrastructure.Validation.Posts;

    public class PostsModel
    {
        [Required]
        [Title]
        public string Title { get; set; }

        [Required]
        [Content]
        public string Content { get; set; }
    }
}
