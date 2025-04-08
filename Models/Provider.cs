using System.ComponentModel.DataAnnotations;

namespace backendcCTRL.Models
{
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }

        [Required]
        public int UserID { get; set; }
        public User User { get; set; }

        public string? LicenseNumber { get; set; }
        public string? Speciality { get; set; }

        public ICollection<Staff>? Staff { get; set; }
    }
}