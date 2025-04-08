using System.ComponentModel.DataAnnotations;

namespace backendcCTRL.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [Required]
        public int UserID { get; set; }
        public User User { get; set; }

        [Required]
        public int ProviderID { get; set; }
        public Provider Provider { get; set; }

        public string? Department { get; set; }
        public string? Gender { get; set; }
        public string? IDNumber { get; set; }
    }
}