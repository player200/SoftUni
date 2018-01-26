namespace _02.SotialNetwork
{
    using System;
    using _02.SotialNetwork.Data;
    using Microsoft.EntityFrameworkCore;
    using _02.SotialNetwork.Model;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //before start check stating class
            using (var db = new SotialNetworkDbContext())
            {
                db.Database.Migrate();

                //----Use to seed data
                //SeedUsers(db);
                //Addting in table AlbumPicture dont work :/
                //SeedAlbumsAndPictures(db);

                //---Task N-1
                //PrintUsersAndTheirFriends(db);

                //---Task N-2
                //PrintActiveUsersWithMoreThanFiveFriends(db);

                //---Task from albums N-1
                //PrintAlbumsWithUserNames(db);

                //---Task from albums N-2 
                //it wont show any becouse AlbumPicure is empty
                //PrintPicuresInMoreThanTwoAlbums(db);

                //---Task from albums N-3
                //it wont show pictures becouse AlbumPicture is empty but other thinks is working
                //PrintAlbumsInfo(db);
            }
        }

        private static void PrintAlbumsInfo(SotialNetworkDbContext db)
        {
            int userId = 2;

            var result = db.Album
                .Where(a => a.Id == userId)
                .Select(a => new
                {
                    Owner = a.User.Name,
                    a.IsPublic,
                    a.Name,
                    Pictures = a.Pictures
                    .Select(p => new
                    {
                        p.Picture.Title,
                        p.Picture.Path
                    })
                })
                .OrderBy(a=>a.Name)
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine(album.Owner);
                if (album.IsPublic)
                {
                    Console.WriteLine(album.Name);
                    foreach (var picture in album.Pictures)
                    {
                        Console.WriteLine($"picute {picture.Title} - path {picture.Path}");
                    }
                }
                else
                {
                    Console.WriteLine(album.Name);
                    Console.WriteLine("Private content!");
                }
            }
        }

        private static void PrintPicuresInMoreThanTwoAlbums(SotialNetworkDbContext db)
        {
            var result = db.Picture
                .Where(p => p.Albums.Count > 2)
                .Select(p => new
                {
                    p.Title,
                    Albums = p.Albums.Select(a => new
                    {
                        Name = a.Album.Name,
                        UserName = a.Album.User.Name
                    })
                })
                .OrderByDescending(p => p.Albums.Count())
                .ThenBy(p => p.Title)
                .ToList();

            foreach (var picutes in result)
            {
                Console.WriteLine($"{picutes.Title}");
                foreach (var album in picutes.Albums)
                {
                    Console.WriteLine($"album {album.Name} - users album {album.UserName}");
                }
            }
        }

        private static void PrintAlbumsWithUserNames(SotialNetworkDbContext db)
        {
            var result = db.Album
                .Select(a => new
                {
                    a.Name,
                    UserName = a.User.Name,
                    Pictures = a.Pictures.Count
                })
                .OrderByDescending(a => a.Pictures)
                .ThenBy(a => a.UserName)
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine($"{album.Name} - user {album.UserName} - pictures {album.Pictures}");
            }
        }

        private static void PrintActiveUsersWithMoreThanFiveFriends(SotialNetworkDbContext db)
        {
            var result = db.Users
                .Where(u => !u.IsDeleted)
                .Where(u => (u.FromFriends.Count + u.ToFriends.Count) > 5)
                .OrderBy(u => u.RegistratedOn)
                .ThenByDescending(u => (u.FromFriends.Count + u.ToFriends.Count))
                .Select(u => new
                {
                    u.Name,
                    FriendsNumber = u.FromFriends.Count + u.ToFriends.Count,
                    Period = DateTime.Now.Subtract(u.RegistratedOn.Value)
                })
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Name} - {user.FriendsNumber}friends - {user.Period.Days} period he was on");
            }
        }

        private static void PrintUsersAndTheirFriends(SotialNetworkDbContext db)
        {
            var result = db.Users
                .Select(u => new
                {
                    u.Name,
                    FriendsNumber = u.FromFriends.Count + u.ToFriends.Count,
                    Status = u.IsDeleted ? "Inactive" : "Active"
                })
                .OrderByDescending(u => u.FriendsNumber)
                .ThenBy(u => u.Name)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"User name = {user.Name}, friends = {user.FriendsNumber}, activity = {user.Status}");
            }
        }

        private static void SeedAlbumsAndPictures(SotialNetworkDbContext db)
        {
            int biggestAlbId = db.Album
                .OrderByDescending(a => a.Id)
                .Select(a => a.Id)
                .FirstOrDefault() + 1;

            List<int> userIds = db.Users
                .Select(u => u.Id)
                .ToList();

            Random random = new Random();

            List<Album> albums = new List<Album>();
            for (int i = biggestAlbId; i < biggestAlbId + 100; i++)
            {
                var album = new Album
                {
                    Name = $"Album {i}",
                    BackgroundColor = $"Color {i}",
                    IsPublic = random.Next(0, 2) == 0 ? true : false,
                    UserId = userIds[random.Next(0, userIds.Count)]
                };
                albums.Add(album);
                db.Album.Add(album);
            }

            db.SaveChanges();

            int biggestPicture = db.Picture
                .Select(p => p.Id)
                .FirstOrDefault() + 1;

            List<Picture> pictures = new List<Picture>();

            for (int i = biggestPicture; i < biggestPicture + 500; i++)
            {
                Picture picture = new Picture
                {
                    Title = $"Picture {i}",
                    Caption = $"Caption {i}",
                    Path = $"Path {i}"
                };
                pictures.Add(picture);
                db.Picture.Add(picture);
            }
            db.SaveChanges();

            //List<int> albumIds = albums.Select(a => a.Id).ToList();
            //for (int i = 0; i < pictures.Count; i++)
            //{
            //    Picture picture = pictures[i];
            //    int numberOfAlbums = random.Next(1,20);
            //    for (int j = 0; j < numberOfAlbums; j++)
            //    {
            //        int albumId = albumIds[random.Next(0, albumIds.Count)];

            //        var pictureExistInAlbum = db.Picture
            //            .Any(p => p.Id == picture.Id && p.Albums.Any(a => a.AlbumId == albumId));

            //        if (pictureExistInAlbum)
            //        {
            //            continue;
            //        }

            //        picture.Albums.Add(new AlbumPicture
            //        {
            //            AlbumId=albumId
            //        });
            //    }
            //    db.SaveChanges();
            //}
        }

        private static void SeedUsers(SotialNetworkDbContext db)
        {
            Console.WriteLine($"Adding db...");

            var allUsers = new List<Users>();

            for (int i = 0; i < 10; i++)
            {
                var user = new Users
                {
                    Name = $"Pesho{i}",
                    Password = "ereara@G0og",
                    Email = $"ddddd.efe@abv{i}.bg",
                    RegistratedOn = DateTime.Now.AddDays(-(100 + i * 10)),
                    LastTimeLoggedIn = DateTime.Now.AddDays(-i),
                    Age = 22
                };

                allUsers.Add(user);
                db.Users.Add(user);
            }

            db.SaveChanges();

            var userId = allUsers
                .Select(u => u.Id)
                .ToList();

            for (int i = 0; i < userId.Count; i++)
            {
                var currentUserId = userId[i];

                Random random = new Random();

                var totalFriends = random.Next(1, 20);

                for (int j = 0; j < totalFriends; j++)
                {
                    var friendId = userId[random.Next(0, userId.Count)];

                    bool validFriendship = true;
                    if (friendId == currentUserId)
                    {
                        validFriendship = false;
                    }

                    var friendShipExists = db
                        .FriendShip
                        .Any(f => (f.FromUserId == currentUserId && f.ToUserId == friendId) ||
                                  (f.FromUserId == friendId && f.ToUserId == currentUserId));
                    if (friendShipExists)
                    {
                        validFriendship = false;
                    }
                    if (!validFriendship)
                    {
                        continue;
                    }

                    db.FriendShip.Add(new FriendShip
                    {
                        FromUserId = currentUserId,
                        ToUserId = friendId
                    });

                    db.SaveChanges();
                }
            }

            Console.WriteLine("Db added!");
        }
    }
}