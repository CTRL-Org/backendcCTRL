using System.ComponentModel.DataAnnotations;

namespace backendcCTRL.Models
{
    public class GlobalHealthStats
    {
        [Key]
        public int StatID { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string DataType { get; set; }

        [Required]
        public string Value { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
