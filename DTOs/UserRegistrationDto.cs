namespace backendcCTRL.DTOs
{
    public class UserRegistrationDto
    {
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }  // Add Role
    }
}
