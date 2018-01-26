namespace CarDealer.Web.Models.Cars
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateCarsModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string CarModel { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        public IEnumerable<int> SelectedParts { get; set; }

        public IEnumerable<SelectListItem> AllParts { get; set; }
    }
}