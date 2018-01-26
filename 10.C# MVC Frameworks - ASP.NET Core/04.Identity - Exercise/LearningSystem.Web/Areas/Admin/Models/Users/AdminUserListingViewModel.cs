namespace LearningSystem.Web.Areas.Admin.Models.Users
{
    using LearningSystem.Service.Admin.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class AdminUserListingViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}