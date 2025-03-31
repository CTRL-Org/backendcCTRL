using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    [Table("patient")]  // Ensure table name matches PostgreSQL
    public class Patient
    {
        [Key]
        [Column("patientid")]
        public int? PatientID { get; set; }  // Made nullable for testing

        [Column("userid")]
        public int? UserID { get; set; }  

        [ForeignKey("UserID")]
        public User? User { get; set; }  

        [StringLength(100)]
        [Column("fullname")]
        public string? FullName { get; set; }  

        [Column("dateofbirth")]
        public DateTime? DateOfBirth { get; set; }  

        [StringLength(10)]
        [Column("gender")]
        public string? Gender { get; set; }  // Made nullable for testing

        [StringLength(20)]
        [Column("idnumber")]
        public string? IDNumber { get; set; }  // Made nullable for testing

        // Navigation properties
        public ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
        public ICollection<HealthStats>? HealthStats { get; set; } = new List<HealthStats>();
    }
}
