using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    public class HealthStats
    {
        [Key]
        [Column("statid")]
        public int StatID { get; set; }

        
        [Column("patientid")]
        public int PatientID { get; set; } 

        // [ForeignKey("patientid")]
        public Patient Patient { get; set; } = null!; 

        
        [StringLength(50)]
        [Column("datatype")]
        public string DataType { get; set; } = null!;

        
        [StringLength(255)]
        [Column("value")]
        public string Value { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
