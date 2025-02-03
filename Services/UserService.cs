using backendcCTRL.DataAccess;
using backendcCTRL.Models;
using backendcCTRL.Services.Interfaces;


namespace backendcCTRL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.UserID);
            if (existingUser == null)
                return null;

            existingUser.Role = user.Role;
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            _context.SaveChanges();

            return existingUser;
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

        public User Authenticate(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
