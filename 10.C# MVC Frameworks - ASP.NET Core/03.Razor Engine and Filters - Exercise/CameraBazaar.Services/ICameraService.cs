namespace CameraBazaar.Services
{
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.Models;
    using System.Collections.Generic;

    public interface ICameraService
    {
        void Create(
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
            string userId);

        IEnumerable<CameraListingModel> All();

        CameraModel ById(int id);

        void Edit(
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
            string imageUrl);

        void Delete(int id);
    }
}