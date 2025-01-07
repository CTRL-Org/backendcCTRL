using System;


namespace Backend.DataAccess
{
    public class User
    {
        public int UserID { get; set; } // Primary Key
        public string Role { get; set; } = string.Empty; // Not Null
        public string Username { get; set; } = string.Empty; // Unique, Not Null
        public string Password { get; set; } = string.Empty; // Not Null
        public string Email { get; set; } = string.Empty; // Unique, Not Null
        public string? PhoneNumber { get; set; } // Optional
    }
}
