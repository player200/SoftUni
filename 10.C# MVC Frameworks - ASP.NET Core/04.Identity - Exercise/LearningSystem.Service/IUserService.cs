namespace LearningSystem.Service
{
    using LearningSystem.Service.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        UserProfileServiceModel Profile(string id);

        Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText);
    }
}