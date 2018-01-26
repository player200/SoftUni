namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenth)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenth)]
        public string LastName { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}