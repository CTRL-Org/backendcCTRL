using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backendcCTRL.Models
{

public class User
{
    [Key]
    public int UserID { get; set; }

    
    [StringLength(50)]
    public required string Role { get; set; }

    
    [StringLength(50)]
    public required string Username { get; set; }

    
    [StringLength(255)]
    public required string Password { get; set; }

    
    [StringLength(100)]
    public required string Email { get; set; }

    [StringLength(15)]
    public string? PhoneNumber { get; set; }
}
}