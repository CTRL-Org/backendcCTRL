public class CreateHealthStatDTO
{
       public int PatientID { get; set; }

    public required string DataType { get; set; }
    public string Value { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Defaults to current time
}
