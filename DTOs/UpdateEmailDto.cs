namespace backendcCTRL.DTOs
{
    public class UpdateEmailDto
    {
        public required int UserId { get; set; }  
        public string? NewEmail { get; set; }  
    }
}
