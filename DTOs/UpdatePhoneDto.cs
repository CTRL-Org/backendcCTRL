namespace backendcCTRL.DTOs
{
    public class UpdatePhoneDto
    {
        public required int UserId { get; set; }  
        public required string NewPhoneNumber { get; set; }  
    }
}
