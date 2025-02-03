namespace backendcCTRL.DTOs
{
    public class UpdatePasswordDto
    {
        public int UserId { get; set; }  
        public required string OldPassword { get; set; }  
        public required string NewPassword { get; set; }  
    }
}
