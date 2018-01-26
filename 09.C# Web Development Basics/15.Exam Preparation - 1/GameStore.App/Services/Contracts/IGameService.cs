namespace GameStore.App.Services.Contracts
{
    using GameStore.App.Data.Models;
    using GameStore.App.Models.Games;
    using GameStore.App.Models.Home;
    using GameStore.App.Models.Orders;
    using System;
    using System.Collections.Generic;

    public interface IGameService
    {
        void Create(
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        void Update(
            int id,
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        void Delete(int id);

        Game GetById(int id);

        bool Exists(int id);

        IEnumerable<GameListingHomeModel> ByIds(IEnumerable<int> ids);

        IEnumerable<GameListingAdminModel> All();

        IEnumerable<GameListingHomeModel> AllHomes();

        IEnumerable<GameListingOrdersModel> ByIdsOrders(IEnumerable<int> ids);
    }
}