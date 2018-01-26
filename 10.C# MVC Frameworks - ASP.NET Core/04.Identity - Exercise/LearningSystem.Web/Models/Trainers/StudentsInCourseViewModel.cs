namespace LearningSystem.Web.Models.Trainers
{
    using LearningSystem.Service.Models;
    using System.Collections.Generic;

    public class StudentsInCourseViewModel
    {
        public IEnumerable<StudentsInCourseServiceModel> Students { get; set; }

        public CourseListingServiceModel Courses { get; set; }
    }
}