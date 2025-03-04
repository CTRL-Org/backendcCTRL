public class CreateAppointmentDTO
{
    public int PatientID { get; set; }
    public DateTime DateTime { get; set; } 
    public string Reason { get; set; } = string.Empty;
}
