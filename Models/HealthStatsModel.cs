using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    public class HealthStats
    {
        [Key]
        [Column("statid")]
        public int StatID { get; set; }

        [Column("patientid")]
        public int PatientID { get; set; }

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; } = null!;

        [Column("height")]
        public decimal? Height { get; set; }

        [Column("weight")]
        public decimal? Weight { get; set; }

        [Column("bloodtype")]
        [StringLength(5)]
        public string? BloodType { get; set; }

        [Column("allergies")]
        [StringLength(500)]
        public string? Allergies { get; set; }

        [Column("lastupdated")]
        public DateTime LastUpdated { get; set; }
    }
}
