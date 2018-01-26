namespace ModPanel.App.Models.Users
{
    using ModPanel.App.Infrastructure.Validation;
    using ModPanel.App.Infrastructure.Validation.Users;

    public class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public int Position { get; set; }
    }
}