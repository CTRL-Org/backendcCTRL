using System;
using System.ComponentModel.DataAnnotations;

public class CreatePatientDTO
{

    public int UserID { get; set; }


    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;


    public DateTime DateOfBirth { get; set; }


    [StringLength(10)]
    public string Gender { get; set; } = string.Empty;

 
    [StringLength(20)]
    public string IdNumber { get; set; } = string.Empty; 
  
    [EmailAddress]
    public string Email { get; set; } = string.Empty;


    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
}
