namespace MedicalAppointment.Application.Dtos.system.Status
{
    public class StatusBaseDto
    {
        public string? StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
