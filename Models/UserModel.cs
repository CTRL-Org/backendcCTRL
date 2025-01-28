using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int UserID { get; set; }

    [Required]
    [StringLength(50)]
    public string Role { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(15)]
    public string PhoneNumber { get; set; }
}
