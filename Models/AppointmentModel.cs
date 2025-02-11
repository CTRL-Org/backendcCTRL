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
        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        public required Patient Patient { get; set; }

        // [Required]
        // public int ProviderID { get; set; } 

        // public Provider Provider { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public required string Reason { get; set; }

        [Required]
        [StringLength(50)]
        public required string Status { get; set; }
    }
}