namespace BookShop.Api.Models.Author
{
    using BookShop.Data;
    using System.ComponentModel.DataAnnotations;

    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenth)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenth)]
        public string LastName { get; set; }
    }
}