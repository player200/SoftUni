namespace _02.SotialNetwork.Model
{
    using _02.SotialNetwork.Model.Validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Users
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [Password]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9]+[.-_]?[a-zA-Z0-9]+)(@)[a-zA-Z0-9]+(\.[a-zA-Z0-9]{2,})+$", ErrorMessage = "Email is invalid!")]
        public string Email { get; set; }

        [MaxLength(1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime? RegistratedOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1,120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public List<FriendShip> FromFriends { get; set; } = new List<FriendShip>();

        public List<FriendShip> ToFriends { get; set; } = new List<FriendShip>();

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}