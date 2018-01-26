namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
    using LearningSystem.Data;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddCourseFormModel
    {
        [Required]
        [MaxLength(DataConstants.CourseNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseDescriptionMaxLenght)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Trainer")]
        [Required]
        public string TrainerId { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }
    }
}