using System.ComponentModel.DataAnnotations;

namespace backendcCTRL.Models
{
    public class HealthStats
    {
        [Key]
        public int StatID { get; set; }

        [Required]
        public int PatientID { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public string DataType { get; set; }

        [Required]
        public string Value { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
