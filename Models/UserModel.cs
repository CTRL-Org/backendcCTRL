using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendcCTRL.Models
{
    [Table("app_user")]
    public class User
    {
        [Key]
        [Column("userid")]
        public int? UserID { get; set; }  

        [StringLength(50)]
        [Column("username")]
        public string? Username { get; set; }  

        [StringLength(100)]
        [Column("email")]
        public string? Email { get; set; }  

        [Column("password")]
        public string? Password { get; set; }  

        [StringLength(20)]
        [Column("role")]
        public string? Role { get; set; }  

        [StringLength(15)]
        [Column("phonenumber")] 
        public string? PhoneNumber { get; set; }  

        // Navigation Property
        public Patient? Patient { get; set; }  
    }
}