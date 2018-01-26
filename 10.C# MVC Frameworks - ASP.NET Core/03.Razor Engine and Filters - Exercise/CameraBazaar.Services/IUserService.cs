namespace CameraBazaar.Services
{
    using CameraBazaar.Services.Models;

    public interface IUserService
    {
        UsersModel ById(string username);

        void Edit(string username, string email, string phone);

        void TimeLoged(string userName);
    }
}