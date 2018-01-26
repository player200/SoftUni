namespace CarDealer.Services.Models
{
    using System.Collections.Generic;

    public class CarsAllModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public IEnumerable<PartsModel> Parts { get; set; }
    }
}