namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int Id { get; set; }

        [Range(0,100)]
        public double Discount { get; set; }

        public int Car_Id { get; set; }

        public Car Car { get; set; }

        public int Customer_Id { get; set; }

        public Customer Customer { get; set; }
    }
}