using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        public int UserID { get; set; } 

        [ForeignKey("UserID")]
        public User User { get; set; } = null!; 

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string IDNumber { get; set; } = null!;

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<HealthStats> HealthStats { get; set; } = new List<HealthStats>();
    }
}