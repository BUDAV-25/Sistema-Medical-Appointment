

namespace MedicalAppointment.Application.Dtos.system.Notification
{
    public class NotificationBaseDto
    {
        public int UserID { get; set; }
        public string? Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
