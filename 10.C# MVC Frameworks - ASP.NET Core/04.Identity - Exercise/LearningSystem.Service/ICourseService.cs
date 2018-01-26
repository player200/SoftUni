namespace LearningSystem.Service
{
    using LearningSystem.Service.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> ActiveAsync();

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText);

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        Task<bool> SignInUser(int courseId, string userId);

        Task<bool> SignOutUser(int courseId, string userId);

        Task<bool> UserIsSignInCourse(int courseId, string userId);
    }
}