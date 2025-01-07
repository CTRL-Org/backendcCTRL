using System;

namespace Backend.DataAccess
{
    public class HealthStats
    {
        public int StatID { get; set; } // Primary Key
        public int PatientID { get; set; } // Foreign Key (references Patient)

        public string DataType { get; set; } = string.Empty; // Not Null
        public string Value { get; set; } = string.Empty; // Not Null
        public DateTime Timestamp { get; set; } = DateTime.Now; // Default to current timestamp

        // Navigation property
        public Patient? Patient { get; set; }
    }
}
