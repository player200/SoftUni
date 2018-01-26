namespace ModPanel.App.Services
{
    using ModPanel.App.Data;
    using ModPanel.App.Data.Models;
    using ModPanel.App.Services.Contracts;
    using System.Linq;
    using System.Collections.Generic;
    using ModPanel.App.Models.Admin;
    using ModPanel.App.Infrastructure;

    public class UserService : IUserService
    {
        public bool Create(string email, string password, PositionType position)
        {
            using (var db = new ModPanelDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                var isAdmin = !db.Users.Any();

                var user = new User
                {
                    Email = email,
                    Password = password,
                    IsAdmin = isAdmin,
                    Position = position,
                    IsApproved = isAdmin
                };

                db.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool UserExists(string email, string password)
        {
            using (var db = new ModPanelDbContext())
            {
                return db
                .Users
                .Any(u => u.Email == email && u.Password == password);
            }
        }

        public bool UserIsApproved(string email)
        {
            using (var db = new ModPanelDbContext())
            {
                return db.Users
                    .Any(u => u.Email == email && u.IsApproved);
            }
        }


        public IEnumerable<AdminUserAdding> All()
        {
            using (var db = new ModPanelDbContext())
            {
                return db.Users
                    .Select(u=>new AdminUserAdding {
                        Id=u.Id,
                        Email=u.Email,
                        Position= u.Position,
                        Posts =u.Posts.Count,
                        IsApproved =u.IsApproved,
                    })
                    .ToList();
            }
        }

        public string Approve(int id)
        {
            using (var db=new ModPanelDbContext())
            {
                var user = db.Users.Find(id);

                if (user!=null)
                {
                    user.IsApproved = true;

                    db.SaveChanges();
                }

                return user?.Email;
            }
        }
    }
}