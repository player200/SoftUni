namespace CameraBazaar.Web.Models.UsersViewModels
{
    using System;

    public class CreateUserModel
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime LastTimeLoged { get; set; }
    }
}