namespace CarDealer.Web.Models.Customers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateCustomerModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BithDate { get; set; }

        public bool IsYoungDrivert { get; set; }
    }
}