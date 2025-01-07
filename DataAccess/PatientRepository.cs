using System;

namespace Backend.DataAccess
{
    public class Patient
    {
        public int PatientID { get; set; } // Primary Key
        public int UserID { get; set; } // Foreign Key (references User)

        public string FullName { get; set; } = string.Empty; // Not Null
        public DateTime DateOfBirth { get; set; } // Not Null
        public string Gender { get; set; } = string.Empty; // Not Null
        public string IDNumber { get; set; } = string.Empty; // Unique, Not Null

        // Navigation property
        public User? User { get; set; }
    }
}
