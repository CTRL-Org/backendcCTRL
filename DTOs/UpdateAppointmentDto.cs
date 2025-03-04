public class UpdateAppointmentDTO
{
    public DateTime DateTime { get; set; }  
    public string Reason { get; set; } = string.Empty;  
    public string Status { get; set; } = "Pending";  
}
