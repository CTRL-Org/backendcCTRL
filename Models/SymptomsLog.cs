using System.ComponentModel.DataAnnotations;

namespace backendcCTRL.Models
{
    public class SymptomsLog
    {
        [Key]
        public int LogID { get; set; }

        [Required]
        public int PatientID { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public string Symptoms { get; set; }

        public string? AIResponse { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
