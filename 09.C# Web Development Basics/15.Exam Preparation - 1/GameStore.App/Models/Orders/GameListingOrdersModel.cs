namespace GameStore.App.Models.Orders
{
    using GameStore.App.Infrastructure.Validation;
    using GameStore.App.Infrastructure.Validation.Games;
    using SimpleMvc.Framework.Attributes.Validation;

    public class GameListingOrdersModel
    {
        public int Id { get; set; }

        [Required]
        [Title]
        public string Title { get; set; }
        
        public decimal Price { get; set; }

        [Required]
        [VideoId]
        public string VideoId { get; set; }

        [Required]
        [ThumbnailUrl]
        public string ThumbnailUrl { get; set; }

        [Required]
        [Description]
        public string Description { get; set; }
    }
}