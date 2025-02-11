using backendcCTRL.Models;

namespace backendcCTRL.Services.Interfaces
{
public interface IUserService
{
    (bool Success, string Message) RegisterUser(UserRegistrationDto user);
    User? Authenticate(UserLoginDto user);
    (bool Success, string Message) UpdateEmail(UpdateEmailDto emailUpdate);
    (bool Success, string Message) UpdatePhoneNumber(UpdatePhoneDto phoneUpdate);
    (bool Success, string Message) UpdatePassword(UpdatePasswordDto passwordUpdate);
}
}