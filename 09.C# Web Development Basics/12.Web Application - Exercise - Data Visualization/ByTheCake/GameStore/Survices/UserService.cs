namespace ByTheCake.GameStore.Survices
{
    using ByTheCake.GameStore.Data;
    using ByTheCake.GameStore.Data.Models;
    using ByTheCake.GameStore.Survices.Contracts;
    using System.Linq;

    public class UserService : IUserService
    {
        public bool Create(string email, string name, string password)
        {
            using (var db = new GameStoreDbContext())
            {
                if (db.User.Any(u => u.Email == email))
                {
                    return false;
                }

                var isAdmin = !db.User.Any();

                var user = new User
                {
                    Email = email,
                    Name = name,
                    Password = password,
                    IsAdmin = isAdmin
                };

                db.Add(user);
                db.SaveChanges();
            }

            return true;
        }

        public bool Find(string email, string password)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.User.Any(u => u.Email == email && u.Password == password);
            }
        }

        public bool IsAdmin(string email)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.User.Any(u => u.Email == email && u.IsAdmin);
            }
        }
    }
}