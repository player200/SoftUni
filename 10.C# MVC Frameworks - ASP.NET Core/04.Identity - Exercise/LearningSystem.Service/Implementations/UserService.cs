namespace LearningSystem.Service.Implementations
{
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Service.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;

        public UserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Users
                .OrderBy(u => u.UserName)
                .Where(u => u.UserName.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<UserListingServiceModel>()
                .ToListAsync();
        }

        public UserProfileServiceModel Profile(string id)
        {
            return this.db
                   .Users
                   .Where(u => u.Id == id)
                   .ProjectTo<UserProfileServiceModel>(new { studentId = id })
                   .FirstOrDefault();
        } 
    }
}