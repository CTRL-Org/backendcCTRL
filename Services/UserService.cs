using backendcCTRL.DataAccess;
using backendcCTRL.Models;
using backendcCTRL.DTOs;
using backendcCTRL.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace backendcCTRL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public (bool Success, string Message) RegisterUser(UserRegistrationDto userDto)
        {
            var newUser = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = userDto.Role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return (true, "User registered successfully.");
        }

        public User? Authenticate(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public (bool Success, string Message) UpdatePassword(UpdatePasswordDto passwordDto)
        {
            var user = _context.Users.Find(passwordDto.UserId);
            if (user == null)
                return (false, "User not found.");

            if (user.Password != passwordDto.OldPassword)
                return (false, "Old password is incorrect.");

            user.Password = passwordDto.NewPassword;
            _context.SaveChanges();
            return (true, "Password updated successfully.");
        }

        public (bool Success, string Message) UpdateEmail(UpdateEmailDto emailDto)
        {
            var user = _context.Users.Find(emailDto.UserId);
            if (user == null)
                return (false, "User not found.");

            user.Email = emailDto.NewEmail;
            _context.SaveChanges();
            return (true, "Email updated successfully.");
        }

        public (bool Success, string Message) UpdatePhoneNumber(UpdatePhoneDto phoneDto)
        {
            var user = _context.Users.Find(phoneDto.UserId);
            if (user == null)
                return (false, "User not found.");

            user.PhoneNumber = phoneDto.NewPhoneNumber ?? user.PhoneNumber;
            _context.SaveChanges();
            return (true, "Phone number updated successfully.");
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id);
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
