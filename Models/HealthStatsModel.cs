using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace backendcCTRL.Models 
{
    public class HealthStats
    {
        [Key]
        public int StatID { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        public Patient Patient { get; set; }

        [Required]
        [StringLength(50)]
        public string DataType { get; set; }

        [Required]
        [StringLength(255)]
        public string Value { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}