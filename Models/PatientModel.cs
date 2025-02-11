using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backendcCTRL.Models
{

public class Patient
{
    [Key]
    public int PatientID { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserID { get; set; }

    public required User User { get; set; }

    [Required]
    [StringLength(100)]
    public required string FullName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(10)]
    public required string Gender { get; set; }

    [Required]
    [StringLength(20)]
    public required string IDNumber { get; set; }
}
}