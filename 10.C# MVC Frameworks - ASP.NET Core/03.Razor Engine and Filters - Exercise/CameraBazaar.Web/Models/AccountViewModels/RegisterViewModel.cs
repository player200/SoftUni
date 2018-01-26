namespace CameraBazaar.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [RegularExpression("[A-Za-z]+",ErrorMessage ="User name must contains only letters.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"\+\d{10,12}",ErrorMessage = "Phone number must start with “+” sign followed by 10 to 12 digits.")]
        public string Phone { get; set; }
    }
}
