using backendcCTRL.Models;

namespace backendcCTRL.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(int id);
        User Authenticate(string username, string password);
    }
}
