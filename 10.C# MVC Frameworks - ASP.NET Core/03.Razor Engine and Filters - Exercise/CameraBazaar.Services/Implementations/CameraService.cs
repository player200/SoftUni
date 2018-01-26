namespace CameraBazaar.Services.Implementations
{
    using CameraBazaar.Data.Models;
    using CameraBazaar.Data;
    using System.Collections.Generic;
    using System.Linq;
    using CameraBazaar.Services.Models;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CameraListingModel> All()
        {
            return this.db
                .Cameras
                .Select(c => new CameraListingModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    ImageUrl = c.ImageUrl
                })
                .ToList();
        }

        public CameraModel ById(int id)
        {
            return this.db
                .Cameras
                .Where(c => c.Id == id)
                .Select(c => new CameraModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    IsFullFrame = c.IsFullFrame,
                    MinShutterSpeed = c.MinShutterSpeed,
                    MaxShutterSpeed = c.MaxShutterSpeed,
                    MinISO = c.MinISO,
                    MaxISO = c.MaxISO,
                    VideoResolution = c.VideoResolution,
                    LightMetering = c.LightMetering,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    UserName = c.User.UserName
                })
                .FirstOrDefault();
        }

        public void Create(
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imageUrl,
            string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var camera = this.db.Cameras.Find(id);

            if (camera == null)
            {
                return;
            }

            this.db.Cameras.Remove(camera);
            this.db.SaveChanges();
        }

        public void Edit(
            int id,
            CameraMake make,
            string model,
            decimal price, 
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO, 
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            string description, 
            string imageUrl)
        {
            var camera = this.db
               .Cameras
               .Where(c => c.Id == id)
               .FirstOrDefault();

            if (camera == null)
            {
                return;
            }

            camera.Make = make;
            camera.Model = model;
            camera.Price = price;
            camera.Quantity = quantity;
            camera.MinShutterSpeed = minShutterSpeed;
            camera.MaxShutterSpeed = maxShutterSpeed;
            camera.MinISO = minISO;
            camera.MaxISO = maxISO;
            camera.IsFullFrame = isFullFrame;
            camera.VideoResolution = videoResolution;
            camera.Description = description;
            camera.ImageUrl = imageUrl;
            this.db.SaveChanges();
        }
    }
}