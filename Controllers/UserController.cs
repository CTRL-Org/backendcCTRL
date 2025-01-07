using Microsoft.AspNetCore.Mvc;
using YourAppNamespace.Services.Interfaces;
using YourAppNamespace.Models.DTOs; // Adjust based on your project namespace
using YourAppNamespace.Models; // Adjust for models like User

namespace YourAppNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; // Interface for user-related business logic

        // Constructor for dependency injection
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // 1. Registration Endpoint
        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegistrationDto user)
        {
            var result = _userService.RegisterUser(user);
            if (result.Success)
                return Ok(result); // Return success response
            return BadRequest(result.Message); // Return error response
        }

        // 2. Login Endpoint
        /// <summary>
        /// Authenticates a user and returns their details if successful.
        /// </summary>
        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] UserLoginDto user)
        {
            var result = _userService.Authenticate(user);
            if (result != null)
                return Ok(result); // Return authenticated user info
            return Unauthorized("Invalid username or password."); // Return unauthorized response
        }

        // 3. Update Email Endpoint
        /// <summary>
        /// Updates the email address of the logged-in user.
        /// </summary>
        [HttpPut("update-email")]
        public IActionResult UpdateEmail([FromBody] UpdateEmailDto emailUpdate)
        {
            var result = _userService.UpdateEmail(emailUpdate);
            if (result.Success)
                return Ok(result.Message); // Return success response
            return BadRequest(result.Message); // Return error response
        }

        // 4. Update Phone Number Endpoint
        /// <summary>
        /// Updates the phone number of the logged-in user.
        /// </summary>
        [HttpPut("update-phone")]
        public IActionResult UpdatePhone([FromBody] UpdatePhoneDto phoneUpdate)
        {
            var result = _userService.UpdatePhoneNumber(phoneUpdate);
            if (result.Success)
                return Ok(result.Message); // Return success response
            return BadRequest(result.Message); // Return error response
        }

        // 5. Update Password Endpoint
        /// <summary>
        /// Updates the password of the logged-in user.
        /// </summary>
        [HttpPut("update-password")]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDto passwordUpdate)
        {
            var result = _userService.UpdatePassword(passwordUpdate);
            if (result.Success)
                return Ok(result.Message); // Return success response
            return BadRequest(result.Message); // Return error response
        }
    }
}
