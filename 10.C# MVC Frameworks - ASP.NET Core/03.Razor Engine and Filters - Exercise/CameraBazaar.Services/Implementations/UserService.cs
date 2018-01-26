namespace CameraBazaar.Services.Implementations
{
    using CameraBazaar.Data;
    using CameraBazaar.Services.Models;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly CameraBazaarDbContext db;

        public UserService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public UsersModel ById(string username)
        {
            return this.db
                .Users
                .Where(u => u.UserName == username)
                .Select(u => new UsersModel
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    Phone = u.PhoneNumber,
                    LastTimeLoged=u.LastTimeLoged,
                    CamerasInStock = u.Cameras
                                    .Where(c => c.UserId == u.Id)
                                    .Select(c => c.Quantity > 0 ? 1 : 0)
                                    .Sum(),
                    CamerasNotInStock = u.Cameras
                                    .Where(c => c.UserId == u.Id)
                                    .Select(c => c.Quantity == 0 ? 1 : 0)
                                    .Sum(),
                    Cameras = u.Cameras
                                .Where(c => c.UserId == u.Id)
                                .Select(c => new CameraListingModel
                                {
                                    Id = c.Id,
                                    Make = c.Make,
                                    Model = c.Model,
                                    Price = c.Price,
                                    Quantity = c.Quantity,
                                    ImageUrl = c.ImageUrl
                                })
                                .ToList()
                })
                .FirstOrDefault();
        }

        public void Edit(string username, string email, string phone)
        {
            var user = this.db
                .Users
                .Where(u => u.UserName == username)
                .FirstOrDefault();

            if (user == null)
            {
                return;
            }

            user.Email = email;
            user.PhoneNumber = phone;
            this.db.SaveChanges();
        }

        public void TimeLoged(string userName)
        {
            var user = this.db
                .Users
                .Where(u => u.UserName == userName)
                .FirstOrDefault();

            user.LastTimeLoged = DateTime.UtcNow;
            this.db.SaveChanges();
        }
    }
}