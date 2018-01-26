namespace ModPanel.App.Services
{
    using System;
    using System.Collections.Generic;
    using ModPanel.App.Data;
    using ModPanel.App.Data.Models;
    using ModPanel.App.Models.Posts;
    using ModPanel.App.Services.Contracts;
    using System.Linq;
    using ModPanel.App.Models.Home;

    public class PostsServices : IPostsServices
    {
        public void Create(string title, string content, int userId)
        {
            using (var db = new ModPanelDbContext())
            {
                var post = new Post
                {
                    Title = title,
                    Content = content,
                    CreatedOn = DateTime.UtcNow,
                    UserId = userId
                };

                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public IEnumerable<PostsAdminToList> All()
        {
            using (var db = new ModPanelDbContext())
            {
                return db.Posts
                    .Select(p => new PostsAdminToList
                    {
                        Id = p.Id,
                        Title = p.Title
                    })
                    .ToList();
            }
        }

        public void Update(int id, string title, string content)
        {
            using (var db = new ModPanelDbContext())
            {
                var post = db.Posts.Find(id);

                if (post == null)
                {
                    return;
                }

                post.Title = title;
                post.Content = content;
                db.SaveChanges();
            }
        }

        public PostsModel GetById(int id)
        {
            using (var db = new ModPanelDbContext())
            {
                return db.Posts.Where(p => p.Id == id)
                     .Select(p => new PostsModel
                     {
                         Title = p.Title,
                         Content = p.Content
                     })
                     .FirstOrDefault();
            }
        }

        public string Delete(int id)
        {
            using (var db = new ModPanelDbContext())
            {
                var post = db.Posts.Find(id);

                if (post == null)
                {
                    return null;
                }

                db.Posts.Remove(post);
                db.SaveChanges();

                return post.Title;
            }
        }

        public IEnumerable<HomeListingModel> AllWithDetails(string search = null)
        {
            using (var db=new ModPanelDbContext())
            {
                var query = db.Posts.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(p => p.Title
                    .ToLower()
                    .Contains(search.ToLower()));
                }

                return query
                    .OrderByDescending(p => p.Id)
                    .Select(q=>new HomeListingModel {
                        Title=q.Title,
                        Content=q.Content,
                        CreatedOn=DateTime.UtcNow,
                        CreatedBy=q.User.Email
                    })
                    .ToList();
            }
        }
    }
}
