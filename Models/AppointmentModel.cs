using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        public int PatientID { get; set; } 

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; } = null!; 

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Reason { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!;
    }
}
