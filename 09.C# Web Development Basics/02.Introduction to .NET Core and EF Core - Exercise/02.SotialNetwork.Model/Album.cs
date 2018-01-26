namespace _02.SotialNetwork.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }

        public Users User { get; set; }

        public List<AlbumPicture> Pictures { get; set; } = new List<AlbumPicture>();
    }
}