using Microsoft.AspNetCore.Mvc;
// using UpdatePasswordDto = backendcCTRL.DTOs.UpdatePasswordDto;
using backendcCTRL.Services.Interfaces;
using backendcCTRL.Models;
using backendcCTRL.DTOs;

namespace back.Controllers
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
            var (success, message) = _userService.RegisterUser(user);
            if (success)
                return Ok(new { message });

            return BadRequest(new { message });
        }


        // 2. Login Endpoint
        /// <summary>
        /// Authenticates a user and returns their details if successful.
        /// </summary>
        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] UserLoginDto user)
        {
            var authenticatedUser = _userService.Authenticate(user);
            if (authenticatedUser != null)
                return Ok(authenticatedUser);

            return Unauthorized(new { message = "Invalid username or password." });
        }


        // 3. Update Email Endpoint
        /// <summary>
        /// Updates the email address of the logged-in user.
        /// </summary>
    [HttpPut("update-email")]
    public IActionResult UpdateEmail([FromBody] UpdateEmailDto emailUpdate)
    {
        var (success, message) = _userService.UpdateEmail(emailUpdate);
        if (success)
            return Ok(new { message });

        return BadRequest(new { message });
    }


        // 4. Update Phone Number Endpoint
        /// <summary>
        /// Updates the phone number of the logged-in user.
        /// </summary>
    [HttpPut("update-phone")]
    public IActionResult UpdatePhone([FromBody] UpdatePhoneDto phoneUpdate)
    {
        var (success, message) = _userService.UpdatePhoneNumber(phoneUpdate);
        if (success)
            return Ok(new { message });

        return BadRequest(new { message });
    }


        // 5. Update Password Endpoint
        /// <summary>
        /// Updates the password of the logged-in user.
        /// </summary>
    [HttpPut("update-password")]
    public IActionResult UpdatePassword([FromBody] UpdatePasswordDto passwordUpdate)
    {
        var (success, message) = _userService.UpdatePassword(passwordUpdate);
        if (success)
            return Ok(new { message });

        return BadRequest(new { message });
    }

    }
}
