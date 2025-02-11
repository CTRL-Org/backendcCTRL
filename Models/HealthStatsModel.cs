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

        public required Patient Patient { get; set; }

        [Required]
        [StringLength(50)]
        public required string DataType { get; set; }

        [Required]
        [StringLength(255)]
        public required string Value { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}