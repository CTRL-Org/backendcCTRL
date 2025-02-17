using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    public class Patient
    {
        [Key]
        [Column("patientid")]
        public int PatientID { get; set; }

        [Required]
        [Column("userid")]
        public int UserID { get; set; } 

        [ForeignKey("userid")]
        public User User { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [Column("fullname")]
        public string FullName { get; set; } = null!;

        [Required]
        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        [Column("gender")]
        public string Gender { get; set; } = null!;

        [Required]
        [StringLength(20)]
        [Column("idnumber")]
        public string IDNumber { get; set; } = null!;

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<HealthStats> HealthStats { get; set; } = new List<HealthStats>();
    }
}
