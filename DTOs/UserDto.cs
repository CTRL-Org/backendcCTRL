// UserDto.cs
namespace backendcCTRL.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
    }
}
