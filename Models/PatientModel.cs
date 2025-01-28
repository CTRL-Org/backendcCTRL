using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Patient
{
    [Key]
    public int PatientID { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserID { get; set; }

    public User User { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(10)]
    public string Gender { get; set; }

    [Required]
    [StringLength(20)]
    public string IDNumber { get; set; }
}
