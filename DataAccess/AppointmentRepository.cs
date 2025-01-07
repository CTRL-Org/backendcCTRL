using System;

namespace Backend.DataAccess
{
    public class Appointment
    {
        public int AppointmentID { get; set; } // Primary Key
        public int PatientID { get; set; } // Foreign Key 
        public int ProviderID { get; set; } // Foreign Key 

        public DateTime DateTime { get; set; } // Not Null
        public string Reason { get; set; } = string.Empty; // Not Null
        public string Status { get; set; } = string.Empty; // Not Null

        // Navigation properties
        public Patient? Patient { get; set; }
        // If Provider is a separate entity, you can add:
        // public Provider? Provider { get; set; }
    }
}
