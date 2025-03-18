using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backendcCTRL.Models
{

[Table("user")]
public class User
{
    [Key]
    [Column("userid")]
    public int UserID { get; set; }

    [Required]
    [StringLength(50)]
    [Column("username")]
    public string Username { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [Column("email")]
    public string Email { get; set; } = null!;

    [Required]
    [Column("password")]
    public string Password { get; set; } = null!;

    [StringLength(20)]
    [Column("role")]
    public string Role { get; set; } = "User";


    [StringLength(15)]
    [Column("phonenumber")]
    public string? PhoneNumber { get; set; } 

    // Navigation Property
    public Patient? Patient { get; set; }
}

}