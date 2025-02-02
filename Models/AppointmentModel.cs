using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTRL.Models 

{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        public Patient Patient { get; set; }

        // [Required]
        // public int ProviderID { get; set; } // Assuming Provider is another model

        // public Provider Provider { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}