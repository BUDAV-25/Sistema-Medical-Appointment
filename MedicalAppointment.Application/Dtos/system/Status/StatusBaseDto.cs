namespace MedicalAppointment.Application.Dtos.system.Status
{
    public class StatusBaseDto
    {
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
