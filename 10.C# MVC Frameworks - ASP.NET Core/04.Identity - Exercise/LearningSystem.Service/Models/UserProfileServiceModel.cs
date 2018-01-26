namespace LearningSystem.Service.Models
{
    using AutoMapper;
    using LearningSystem.Common.Mapping;
    using LearningSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserProfileServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public IEnumerable<UsersProfileCourseServiceModel> Courses { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
               .CreateMap<User, UserProfileServiceModel>()
               .ForMember(u => u.Courses, cfg => cfg.MapFrom(s => s.Courses.Select(c => c.Course)));
        } 
    }
}