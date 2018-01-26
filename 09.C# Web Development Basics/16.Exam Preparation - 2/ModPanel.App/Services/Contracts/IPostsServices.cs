namespace ModPanel.App.Services.Contracts
{
    using ModPanel.App.Models.Home;
    using ModPanel.App.Models.Posts;
    using System.Collections.Generic;

    public interface IPostsServices
    {
        void Create(string title, string content,int userId);

        IEnumerable<PostsAdminToList> All();

        void Update(int id, string title, string content);

        PostsModel GetById(int id);

        string Delete(int id);

        IEnumerable<HomeListingModel> AllWithDetails(string search = null);
    }
}