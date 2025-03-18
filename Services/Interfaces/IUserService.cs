using backendcCTRL.Models;
using backendcCTRL.DTOs;
using System.Collections.Generic;

namespace backendcCTRL.Services.Interfaces
{
    public interface IUserService
    {
        (bool Success, string Message) RegisterUser(UserRegistrationDto user);
        User? Authenticate(string username, string password);
        (bool Success, string Message) UpdatePassword(UpdatePasswordDto passwordUpdate);
        (bool Success, string Message) UpdateEmail(UpdateEmailDto emailUpdate);
        (bool Success, string Message) UpdatePhoneNumber(UpdatePhoneDto phoneUpdate);
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        bool DeleteUser(int id);
    }
}
