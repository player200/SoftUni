namespace BookShop.Api.Models.Book
{
    using BookShop.Data;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateBookRequestModel
    {
        [Required]
        [MinLength(DataConstants.BookTitleMinLenth)]
        [MaxLength(DataConstants.BookTitleMaxLenth)]
        public string Title { get; set; }

        [Required]
        public string Descrtioption { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }
        
        public string Categories { get; set; }
    }
}