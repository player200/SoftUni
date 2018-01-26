namespace LearningSystem.Service
{
    using LearningSystem.Data.Models;
    using LearningSystem.Service.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainerService
    {
        Task<IEnumerable<CourseListingServiceModel>> ByTrainer(string trainerId);

        Task<bool> IsTrainer(int courseId, string trainerId);

        Task<IEnumerable<StudentsInCourseServiceModel>> StudentsInCourseAsync(int courseId);

        Task<bool> AddGrade(int courseId, string studentId, Grade grade);
    }
}