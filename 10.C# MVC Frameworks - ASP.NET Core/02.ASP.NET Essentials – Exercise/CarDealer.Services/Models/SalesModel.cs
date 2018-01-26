namespace CarDealer.Services.Models
{
    public class SalesModel
    {
        public string CarMake { get; set; }

        public string CarModel { get; set; }

        public long CarTravelledDistance { get; set; }

        public string CustromerName { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }
    }
}