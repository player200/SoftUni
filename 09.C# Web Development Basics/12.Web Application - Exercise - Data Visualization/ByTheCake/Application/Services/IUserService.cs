namespace ByTheCake.Application.Services
{
    using ByTheCake.Application.Resources.Data.Models;
    using ByTheCake.Application.ViewModel.Account;

    public interface IUserService
    {
        bool Create(string username, string password);

        bool Find(string username, string password);

        ProfileViewModel Profile(string username);

        int? GetUserId(string username);
    }
}