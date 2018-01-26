namespace GameStore.App.Models.Home
{
    using GameStore.App.Infrastructure.Validation;
    using GameStore.App.Infrastructure.Validation.Games;
    using SimpleMvc.Framework.Attributes.Validation;

    public class GameListingHomeModel
    {
        public int Id { get; set; }

        [Required]
        [Title]
        public string Title { get; set; }
        
        public decimal Price { get; set; }
        
        public double Size { get; set; }

        [Required]
        [ThumbnailUrl]
        public string ThumbnailUrl { get; set; }

        [Required]
        [VideoId]
        public string VideoId { get; set; }

        [Required]
        [Description]
        public string Description { get; set; }
    }
}