namespace LearningSystem.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class SearchFormModel
    {
        public string SearchInText { get; set; }

        [Display(Name = "Search in uses")]
        public bool SearchInUsers { get; set; } = true;

        [Display(Name = "Search in courses")]
        public bool SearchInCourses { get; set; } = true;
    }
}