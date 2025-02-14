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
        public int PatientID { get; set; } 

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; } = null!; 

        [Required]
        [StringLength(50)]
        public string DataType { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Value { get; set; } = null!;

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
