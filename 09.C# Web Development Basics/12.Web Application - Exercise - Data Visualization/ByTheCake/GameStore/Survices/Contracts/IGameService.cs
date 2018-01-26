namespace ByTheCake.GameStore.Survices.Contracts
{
    using ByTheCake.GameStore.ViewModels.Admin;
    using System;
    using System.Collections.Generic;

    public interface IGameService
    {
        void Create(
           string title,
           string description,
           string image,
           decimal price,
           double size,
           string videoId,
           DateTime releaseDate);

        IEnumerable<AdminListGameViewModel> All();
    }
}