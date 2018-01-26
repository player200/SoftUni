namespace LearningSystem.Web.Models.Home
{
    using LearningSystem.Service.Models;
    using System.Collections.Generic;

    public class HomeIndexViewModel :SearchFormModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; }
    }
}