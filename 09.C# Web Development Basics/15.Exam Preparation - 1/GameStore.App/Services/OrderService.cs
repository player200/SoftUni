namespace GameStore.App.Services
{
    using GameStore.App.Data;
    using GameStore.App.Data.Models;
    using GameStore.App.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        public void Purchase(int userId, IEnumerable<int> gameIds)
        {
            using (var db = new GameStoreDbContext())
            {
                var alreadyOwnedIds =db
                                .Orders
                                .Where(o => o.UserId == userId
                                    && gameIds.Contains(o.GameId))
                                .Select(o => o.GameId)
                                .ToList();

                var newGamesIds = new List<int>(gameIds);

                foreach (var gameId in alreadyOwnedIds)
                {
                    newGamesIds.Remove(gameId);
                }

                foreach (var newGameId in newGamesIds)
                {
                    var order = new Order
                    {
                        GameId = newGameId,
                        UserId = userId
                    };

                    db.Orders.Add(order);
                }

                db.SaveChanges();
            }
        }
    }
}