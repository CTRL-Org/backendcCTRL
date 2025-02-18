using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    public class Appointment
    {
        [Key]
        [Column("appointmentid")] 
        public int AppointmentID { get; set; }

        [Required]
        [Column("patientid")]
        public int PatientID { get; set; } 

        // [ForeignKey("patientid")]
        public Patient? Patient { get; set; }

        
        [Column("datetime")]  // 
        public DateTime DateTime { get; set; }

        
        [Column("reason")]
        public string Reason { get; set; } = null!;

        
        [StringLength(50)]
        [Column("status")]
        public string Status { get; set; } = null!;
    }
}
