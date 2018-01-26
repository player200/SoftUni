namespace LearningSystem.Service.Implementations
{
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Service.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> ActiveAsync()
        {
            return await this.db
                .Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.StartDate >= DateTime.UtcNow)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();
        }

        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
        {
            return await this.db
                .Courses
                .Where(c => c.Id == id)
                .ProjectTo<TModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();
        }

        public async Task<bool> SignInUser(int courseId, string userId)
        {
            var courseInfo = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    c.StartDate,
                    UserIdSignedIn = c.Students.Any(s => s.StudentId == userId)
                })
                .FirstOrDefaultAsync();

            if (courseInfo == null
                || courseInfo.StartDate < DateTime.UtcNow
                || courseInfo.UserIdSignedIn)
            {
                return false;
            }

            var studentCourses = new StudentCourse
            {
                CourseId = courseId,
                StudentId = userId
            };

            this.db.Add(studentCourses);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutUser(int courseId, string userId)
        {
            var courseInfo = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    c.StartDate,
                    UserIdSignedIn = c.Students.Any(s => s.StudentId == userId)
                })
                .FirstOrDefaultAsync();

            if (courseInfo == null
                || courseInfo.StartDate < DateTime.UtcNow
                || !courseInfo.UserIdSignedIn)
            {
                return false;
            }

            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(userId, courseId);

            this.db.Remove(studentInCourse);
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserIsSignInCourse(int courseId, string userId)
        {
            return await this.db
                .Courses
                .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == userId));
        }
    }
}