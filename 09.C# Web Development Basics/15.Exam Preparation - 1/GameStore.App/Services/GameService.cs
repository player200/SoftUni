
namespace GameStore.App.Services
{
    using GameStore.App.Data;
    using GameStore.App.Data.Models;
    using GameStore.App.Models.Games;
    using GameStore.App.Models.Home;
    using GameStore.App.Models.Orders;
    using GameStore.App.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameService : IGameService
    {
        public void Create(
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = new Game
                {
                    Title = title,
                    Description = description,
                    Price = price,
                    Size = size,
                    ThumbnailUrl = thumbnailUrl,
                    VideoId = videoId,
                    ReleaseDate = releaseDate
                };

                db.Games.Add(game);
                db.SaveChanges();
            }
        }

        public void Update(
            int id,
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = db.Games.Find(id);

                game.Title = title;
                game.Description = description;
                game.ThumbnailUrl = thumbnailUrl;
                game.Price = price;
                game.Size = size;
                game.VideoId = videoId;
                game.ReleaseDate = releaseDate;

                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = db.Games.Find(id);
                db.Games.Remove(game);

                db.SaveChanges();
            }
        }

        public Game GetById(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games.Find(id);
            }
        }

        public bool Exists(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games.Any(g => g.Id == id);
            }
        }
           

        public IEnumerable<GameListingHomeModel> ByIds(IEnumerable<int> ids)
        {
            using (var db = new GameStoreDbContext())
            {
                return db
                   .Games
                   .Where(g => ids.Contains(g.Id))
                   .Select(g => new GameListingHomeModel
                   {
                       Id = g.Id,
                       Description = g.Description,
                       Price = g.Price,
                       Size = g.Size,
                       ThumbnailUrl = g.ThumbnailUrl,
                       Title = g.Title,
                       VideoId = g.VideoId
                   })
                   .ToList();
            } 
        }

        public IEnumerable<GameListingAdminModel> All()
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games.Select(g => new GameListingAdminModel
                {
                    Id = g.Id,
                    Name = g.Title,
                    Price = g.Price,
                    Size = g.Size
                })
                .ToList();
            }
        }

        public IEnumerable<GameListingHomeModel> AllHomes()
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games.Select(g => new GameListingHomeModel
                {
                    Id = g.Id,
                    VideoId = g.VideoId,
                    Title = g.Title,
                    ThumbnailUrl = g.ThumbnailUrl,
                    Size = g.Size,
                    Price = g.Price,
                    Description = g.Description
                })
                .ToList();
            }
        }

        public IEnumerable<GameListingOrdersModel> ByIdsOrders(IEnumerable<int> ids)
        {
            using (var db = new GameStoreDbContext())
            {
                return db
                   .Games
                   .Where(g => ids.Contains(g.Id))
                   .Select(g => new GameListingOrdersModel
                   {
                       Id = g.Id,
                       Description = g.Description,
                       Price = g.Price,
                       ThumbnailUrl = g.ThumbnailUrl,
                       Title = g.Title,
                       VideoId = g.VideoId
                   })
                   .ToList();
            }
        }
    }
}