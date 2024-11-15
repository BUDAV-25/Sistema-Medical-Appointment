namespace MedicalAppointment.Application.Dtos.system.Status
{
    public class StatusUpdateDto : StatusBaseDto
    {
        public int StatusID { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
