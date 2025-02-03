namespace backendcCTRL.DTOs
{
    public class UpdatePasswordDto
    {
        public int UserId { get; set; }  
        public string OldPassword { get; set; }  
        public string NewPassword { get; set; }  
    }
}
