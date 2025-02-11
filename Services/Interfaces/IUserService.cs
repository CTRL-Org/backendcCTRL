using backendcCTRL.Models;
using backendcCTRL.DTOs;

namespace backendcCTRL.Services.Interfaces
{
public interface IUserService
{
    (bool Success, string Message) RegisterUser(UserRegistrationDto user);
    User Authenticate(string username, string password);

    (bool Success, string Message) UpdateEmail(UpdateEmailDto emailUpdate);
    (bool Success, string Message) UpdatePhoneNumber(UpdatePhoneDto phoneUpdate);
    (bool Success, string Message) UpdatePassword(UpdatePasswordDto passwordUpdate);

    
}
}