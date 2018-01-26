namespace CameraBazaar.Services.Models
{
    using System;
    using System.Collections.Generic;

    public class UsersModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int CamerasInStock { get; set; }

        public int CamerasNotInStock { get; set; }

        public DateTime LastTimeLoged { get; set; }

        public IEnumerable<CameraListingModel> Cameras { get; set; }
    }
}