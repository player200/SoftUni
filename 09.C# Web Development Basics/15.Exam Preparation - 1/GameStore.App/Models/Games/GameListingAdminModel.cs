using GameStore.App.Infrastructure.Validation;
using SimpleMvc.Framework.Attributes.Validation;

namespace GameStore.App.Models.Games
{
    public class GameListingAdminModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public double Size { get; set; }
        
        public decimal Price { get; set; }
    }
}