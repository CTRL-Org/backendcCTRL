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
        public int PatientID { get; set; }  // ✅ Change from long to int

        [Column("userid")]
        public int UserID { get; set; }  // ✅ Change from long to int

        [ForeignKey("UserID")]
        public User User { get; set; } = null!;

        [StringLength(100)]
        [Column("fullname")]
        public string FullName { get; set; } = null!;

        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }  // ✅ Reverted from DateOnly to DateTime

        [StringLength(10)]
        [Column("gender")]
        public string Gender { get; set; } = null!;

        [StringLength(20)]
        [Column("idnumber")]
        public string IDNumber { get; set; } = null!;

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<HealthStats> HealthStats { get; set; } = new List<HealthStats>();
    }

}
